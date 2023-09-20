import { JSONSchema7 } from "json-schema";
import { CodeLanguage } from "../domain/Enums";

export interface GenerateTypeCodePort {
    generateTypeCode(language: CodeLanguage, schemas: InterfaceSchema[]) : Promise<TypeCode[]>
}

export class InterfaceSchema {
    readonly namespace: string;
    readonly name: string;
    readonly description: string;
    readonly parameters?: NamedOpenApiDataType[];
    readonly response?: OpenApiDataType;

    constructor(namespace: string, name: string, description: string, parameters?: { [key: string]: JSONSchema7; }, response?: JSONSchema7) {
        this.namespace = namespace;
        this.name = name;
        this.description = description;
        if(parameters) {
            this.parameters = Object.entries(parameters)
                .map(entry => {
                    const schema = entry[1] as NamedOpenApiDataType;
                    schema.name = entry[0];
                    return schema;
                });
        }
        else {
            this.parameters = [];
        }

        if(this.response)
            this.response = response as OpenApiDataType;
    }   
}


export interface NamedOpenApiDataType extends JSONSchema7 {
    name: string;
}

export interface OpenApiDataType extends JSONSchema7 {
    nullable?: boolean;
    values?: string[]
}

export class TypeCode {
    readonly namespace: string;
    readonly name: string;
    readonly code: string;

    constructor(namespace: string, name: string, code: string) {
        this.namespace = namespace;
        this.name = name;
        this.code = code;
    }
}