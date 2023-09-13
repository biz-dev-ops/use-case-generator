import { JSONSchema7 } from "json-schema";

export interface GetUseCaseModelPort {
    getUseCaseModel(path: string) : Promise<UseCaseModel>;
}

export class UseCaseModel {
    readonly name: string;
    readonly description: string;
    readonly parameters?: { [key: string]: JSONSchema7; };
    readonly response?: JSONSchema7;
    
    constructor(data: any) {
        if(!data.name)
            throw new Error("Validation error: name is not supplied.");

        this.name = data.name as string;
        this.description = data.description as string;
        if(data.parameters) {
            this.parameters = data.parameters as { [key: string]: JSONSchema7; };
        }
        if(data.response) {
            this.response = data.response as JSONSchema7;
        }
    }
}