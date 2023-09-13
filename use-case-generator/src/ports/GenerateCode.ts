import { JSONSchema7 } from "json-schema";
import { CodeLanguage } from "../domain/Enums";

export interface GenerateCodePort {
    generateCode(language: CodeLanguage, schemas: InterfaceSchema[]) : Promise<Code[]>
}

export class InterfaceSchema {
    readonly name: string;
    readonly description: string;
    readonly parameters?: { [key: string]: JSONSchema7; };
    readonly response?: JSONSchema7;

    constructor(name: string, description: string, parameters?: { [key: string]: JSONSchema7; }, response?: JSONSchema7) {
        this.name = name;
        this.description = description;
        this.parameters = parameters;
        this.response = response;
    }
}

export class Code {

}