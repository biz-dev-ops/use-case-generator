import {JSONSchema7} from 'json-schema';
import { GetFileReferencePort } from './GetFileReference';

export interface GetUseCaseSchemaPort {
    getUseCaseSchema(path: string) : Promise<UseCaseSchema>;
}

export class GetUseCaseSchemaPortImpl implements GetUseCaseSchemaPort {
    private getFileReferencePort: GetFileReferencePort;
    
    constructor(getFileReferencePort: GetFileReferencePort) {
        this.getFileReferencePort =  getFileReferencePort;
    }
    
    async getUseCaseSchema(path: string): Promise<UseCaseSchema> {
        const file = await this.getFileReferencePort.getFileReference(path);
        const json = await file.readJson();
        json.name = json.name || file.name;
        return new UseCaseSchema(json);
    }

}

export default class UseCaseSchema {
    name: string;
    description: string;
    parameters:  Map<string, JSONSchema7>;
    response: JSONSchema7;
    
    constructor(data: any) {
        if(!data.name)
            throw new Error("Validation error: name is not supplied.");

        this.name = data.name as string;
        this.description = data.description as string;
        this.parameters = data.parameters as Map<string, JSONSchema7>;
        this.response = data.response as JSONSchema7;
    }
}