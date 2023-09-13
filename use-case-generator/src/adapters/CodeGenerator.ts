import { JSONSchema7 } from "json-schema";
import { CodeLanguage } from "../domain/Enums";
import { Code, GenerateCodePort, InterfaceSchema } from "../ports/GenerateCode";
import { GenerateTypePort } from "../ports/GenerateType";

//TODO: find opensource generator which can generator interfaces in any language.
export class CodeGenerator implements GenerateCodePort {
    private readonly generateTypePort: GenerateTypePort;

    constructor(generateTypePort: GenerateTypePort) {
        this.generateTypePort = generateTypePort;
    }

    generateCode(language: CodeLanguage, schemas: [InterfaceSchema]): Promise<Code[]> {
        return Promise.all(
            schemas.map(async (schema) => await this.createInterface(language, schema))
        );
    }

    private async createInterface(language: CodeLanguage, schema: InterfaceSchema) : Promise<Code> {
        const namespace: string = "todo";
        
        const parameters = await this.createParameters(language, "todo", schema.parameters)
        const response = await this.createResponse(language, namespace, `${schema.name} response`, schema.response);

        //todo: create interface.

        return new Code();
    }
    private async createParameters(language: CodeLanguage, namespace: string, parameters?: { [key: string]: JSONSchema7; }) : Promise<GeneratedType[]> {
        if(!parameters)
            return [];
        
        return await Promise.all(
            Object.entries(parameters)
                .map(entry => ({ key: entry[0], value: entry[1]}))
                .map(async (entry) => {
                    const name = entry.key;
                    const type = entry.value.type?.toString() || "object";
                    
                    if(type !== "object")
                        return new GeneratedType(name, type);

                    const code = await this.generateTypePort.generateType(language, namespace, entry.key, entry.value);

                    return new GeneratedType(name, type, code);
                })
        );
    }

    private async createResponse(language: CodeLanguage, namespace: string, name: string, schema?: JSONSchema7) : Promise<GeneratedType | undefined> {
        if(!schema)
            return;

        const type = schema.type?.toString() || "object";
        
        if(type !== "object")
            return new GeneratedType(name, type);

        const code = await this.generateTypePort.generateType(language, namespace, name, schema);

        return new GeneratedType(name, type, code);
    }
}

class GeneratedType {
    readonly name: string;
    readonly type: string;
    readonly code?: string;

    constructor(name: string, type: string, code?: string) {
        this.name = name;
        this.type = type;
        this.code = code;
    }
}