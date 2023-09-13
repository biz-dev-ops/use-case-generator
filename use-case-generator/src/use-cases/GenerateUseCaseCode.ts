import { CodeLanguage } from "../domain/Enums";

export interface GenerateUseCaseCode {
    generateUseCaseCode(language: CodeLanguage, source: string, destination: string) : Promise<void>;
}