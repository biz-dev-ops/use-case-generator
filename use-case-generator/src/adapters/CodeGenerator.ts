import { CodeLanguage } from "../domain/Enums";
import { GenerateTypeCodePort, TypeCode, InterfaceSchema, NamedOpenApiDataType, OpenApiDataType } from "../ports/GenerateTypeCode";
import { GenerateTypePort } from "../ports/GenerateType";
import { scheduler } from "timers/promises";

//TODO: find opensource generator which can generator interfaces in any language.
export class CodeGenerator implements GenerateTypeCodePort {
    private readonly generateTypePort: GenerateTypePort;

    constructor(generateTypePort: GenerateTypePort) {
        this.generateTypePort = generateTypePort;
    }

    async generateTypeCode(language: CodeLanguage, schemas: [InterfaceSchema]): Promise<TypeCode[]> {
        return await Promise.all(
            schemas
                .map(async (schema) => await this.generateInterface(language, schema))
        )
        .then(generatedInterfaces => 
            generatedInterfaces.flatMap(generatedInterface => { 
                const code: TypeCode[] = [new TypeCode(
                    generatedInterface.namespace,
                    generatedInterface.name,
                    generatedInterface.code
                )];

                if(generatedInterface.parameters) {
                    code.push(
                        ...generatedInterface.parameters
                            ?.filter(p => p.definition instanceof GeneratedCustomType)
                            .map(p => p.definition as GeneratedCustomType)
                            .map(t => mapGeneratedCustomTypeToTypeCode(t))
                    );
                }
                
                if(generatedInterface.response && generatedInterface.response instanceof GeneratedCustomType) {
                    code.push(mapGeneratedCustomTypeToTypeCode(generatedInterface.response))
                }
                
                return code;
            })
        );
    }

    private async generateInterface(language: CodeLanguage, schema: InterfaceSchema) : Promise<GeneratedInterface> {
        const definition = new InterfaceDefinition(
            schema.namespace,
            schema.name,
            schema.description,
            mapOpenApiDataTypesParemeterTypeDefinitions(schema.parameters),
            mapOpenApiDataTypeToResponseTypeDefinition(schema.response)
        );

        throw new Error("Not implemented exception");
        //Todo: generate interface code => generate types and generate interfaces
        const code = "";

        return new GeneratedInterface(
            definition.namespace, 
            definition.name,
            code,
            definition.description,
            definition.parameters,
            definition.response
        );
    }
}

const mapOpenApiDataTypeToTypeDefinition = (schema: OpenApiDataType) : TypeDefinition => {
    if(!schema.title)
        throw new Error("JSONSchema error: title is not defined.");

    const nullable =  (schema as { nullable?: boolean}).nullable ?? false;

    if(schema.type == "object" || schema.properties) {
        return new CustomType("", schema.title, nullable);
    }
    
    const type = mapJsonSchemaTypeToType(schema);

    if(!schema.values) {
        return new PrimitiveType(type, nullable);
    }
    else {
        return new EnumType(type, nullable, schema.values)
    }
}

const mapJsonSchemaTypeToType = (schema: OpenApiDataType) : Type => {
    switch(schema.type) {
        case "string":
            switch(schema.format) {
                case "date":
                    return Type.Date;
                case "date-time":
                    return Type.DateTime;
                case "uuid":
                    return Type.UUID;
                default:
                    return Type.String;
            }
        case "number":
            switch(schema.format) {
                case "float":
                    return Type.Integer;
                case "double":
                    default:
                    return Type.Long;
            }
        case "integer":
            switch(schema.format) {
                case "int32":
                    return Type.Integer;
                case "int64":
                    default:
                    return Type.Long;
            }
        case "boolean":
            return Type.Boolean;
        case "array":
            throw new Error("Not implemented");
        default:
            throw new Error(`JSONSchema error: type "${schema.type}" is not supported.`);
    }
}

const mapOpenApiDataTypeToResponseTypeDefinition = (schema?: OpenApiDataType) : ResponseTypeDefinition => {
    if(!schema)
        return new Void();

   return mapOpenApiDataTypeToTypeDefinition(schema);
}

const mapOpenApiDataTypesParemeterTypeDefinitions = (dataTypes?: NamedOpenApiDataType[]) :  ParameterTypeDefinition[] => {
    if(!dataTypes)
        return [];

    return dataTypes.map(t => {
        //Todo: transform x-ref-path to title
        t.title = t.title ?? t.name;

        return {
            name: t.name,
            definition: mapOpenApiDataTypeToTypeDefinition(t)
        };
    });
}

const mapGeneratedCustomTypeToTypeCode = (type: GeneratedCustomType) : TypeCode => {
    return new TypeCode(type.namespace, type.name, type.code);
}

class InterfaceDefinition {
    readonly namespace: string;
    readonly name: string;
    readonly description?: string;
    readonly parameters?: ParameterTypeDefinition[];
    readonly response?: ResponseTypeDefinition;

    constructor(namespace: string, name: string, description?: string, parameters?: ParameterTypeDefinition[], response?: ResponseTypeDefinition) {
        this.namespace = namespace;
        this.name = name;
        this.description = description;
        this.parameters = parameters;
        this.response = response;
    }
}

class GeneratedInterface extends InterfaceDefinition {
    readonly code: string
    
    constructor(namespace: string, name: string, code: string, description?: string, parameters?: ParameterTypeDefinition[], response?: ResponseTypeDefinition) {
        super(namespace, name, description, parameters, response);
        this.code = code;
    }
}

type ParameterTypeDefinition  = { name: string, definition: TypeDefinition };
type ResponseTypeDefinition = Void | TypeDefinition;
type TypeDefinition = PrimitiveType | EnumType | CustomType | GeneratedCustomType;

class Void {};

class PrimitiveType {
    readonly type: Type | string;
    readonly nullable: boolean;

    constructor(type: Type | string, nullable: boolean) {
        this.type = type;
        this.nullable = nullable;
    }
}

class EnumType extends PrimitiveType {
    readonly values: string[];

    constructor(type: string, nullable: boolean, values: string[]) {
        super(type, nullable);
        this.values = values;
    }
}

class CustomType extends PrimitiveType {
    readonly namespace: string;

    constructor(namespace: string, type: string, nullable: boolean) {
        super(type, nullable);
        this.namespace = namespace;
    }
}

class GeneratedCustomType extends CustomType {
    readonly name: string;
    readonly code: string;

    constructor(namespace: string, name: string, nullable: boolean, code: string) {
        super(namespace, "object", nullable);
        this.name = name;
        this.code = code;
    }
}

enum Type {
    String = "string",
    Date = "date",
    DateTime = "date-time",
    UUID = "uuid",
    Float = "float",
    Double = "double",
    Integer = "integer",
    Long = "long",
    Boolean = "boolean"
}