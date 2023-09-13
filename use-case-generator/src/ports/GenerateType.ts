import { JSONSchema7 } from "json-schema";
import { CodeLanguage } from "../domain/Enums";

export interface GenerateTypePort {
    generateType(language: CodeLanguage, namespace: string, name: string, schema: JSONSchema7) : Promise<string>
}