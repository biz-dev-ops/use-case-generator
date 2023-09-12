import { LanguageOption } from "../ports/GetOptions";

export interface CreateUseCaseCode {
    handle(language: LanguageOption, source: string, destination: string) : Promise<void>;
}