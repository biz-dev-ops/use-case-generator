import { bundle } from "@apidevtools/json-schema-ref-parser";
import mergeAllOf from "json-schema-merge-allof"
import { dirname  } from "path";

import { GetFileReferencePort } from "../ports/GetFileReference";
import { GetUseCaseModelPort, UseCaseModel } from "../ports/GetUseCaseModel";

export class JsonSchemaAdapter  implements GetUseCaseModelPort {
    private getFileReferencePort: GetFileReferencePort;
    
    constructor(getFileReferencePort: GetFileReferencePort) {
        this.getFileReferencePort =  getFileReferencePort;
    }
    
    async getUseCaseModel(path: string): Promise<UseCaseModel> {
        const file = await this.getFileReferencePort.getFileReference(path);
        const json = await file.readJson();
        json.name = json.name || file.name;

        //mergeAllOfInSchema(json);
        await deReferenceSchema(dirname(path), json);

        return new UseCaseModel(json);
    }
}

const deReferenceSchema = async (path: string, json: any) : Promise<void> => {
    const cwd = process.cwd();
    process.chdir(path);

    try {
        if(json.parameters) {
            json.parameters = await bundle(json.parameters, {
                dereference: {
                    onDereference: (path: string, schema: any) => {
                        schema["x-ref-path"] = path;
                    }
                }
            });
        }

        if(json.response) {
            json.response = await bundle(json.response);
        }
    }
    finally {
        process.chdir(cwd);
    }
}

const mergeAllOfInSchema = (json:any) : void => {
    const _merge = (object:any) => {
        if(!!object["allOf"]){
            object = mergeAllOf(object, {
                resolvers: {
                    defaultResolver: mergeAllOf.options.resolvers.title
                }
              });
        }
      
        for (let key in object) {
            if(typeof object[key] == "object"){
                object[key] = _merge(object[key])
            }
        }
    
        return object;
    };

    _merge(json);
}