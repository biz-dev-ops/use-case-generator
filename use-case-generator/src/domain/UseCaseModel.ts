import { GenerateTypePort } from "../ports/GenerateType";
import { LanguageOption } from "../ports/GetOptions";

export default class UseCaseModel {
    name: string;
    description: string;
    parameters:  Map<string, string>;
    response: string;
    
    constructor(data: any) {
        if(!data.name)
            throw new Error("Validation error: name is not supplied.");

        this.name = data.name as string;
        this.description = data.description as string;
        this.parameters = data.parameters as Map<string, string>;
        this.response = data.response;
    }

    async generateCodeFor(language: LanguageOption, generateTypePort: GenerateTypePort) : Promise<any> {
        //parameters and response contain references and allOf. These need to be fixed first
        //Then generate types for every type: object in the json-schema
        //Create interface with references to generated types or native types.
    }
}