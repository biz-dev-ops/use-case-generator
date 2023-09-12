import { JSONSchema7 } from "json-schema";
import { LanguageOption } from "./GetOptions";

export interface GenerateTypePort {
    generateType(language: LanguageOption, name: string, schema: string) : Promise<string>
}