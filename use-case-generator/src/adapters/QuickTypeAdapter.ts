import { quicktype, InputData, JSONSchemaInput, FetchingJSONSchemaStore } from "quicktype-core";
import { JSONSchema7 } from "json-schema";

import { GenerateTypePort } from "../ports/GenerateType";
import { LogMesssagePort } from "../ports/LogMessage";
import { CodeLanguage } from "../domain/Enums";

export class QuickTypeAdapter implements GenerateTypePort {
    private readonly logger: LogMesssagePort;

    constructor(logMessagePort: LogMesssagePort) {
        this.logger = logMessagePort;
    }
    async generateType(language: CodeLanguage, namespace: string, name: string, schema: JSONSchema7): Promise<string> {
        const schemaInput = new JSONSchemaInput(new FetchingJSONSchemaStore());

        await schemaInput.addSource( { 
            name: name, 
            schema: JSON.stringify(schema, null, 3)
        });

        const inputData = new InputData();
        inputData.addInput(schemaInput)

        const result = await quicktype({
            inputData,
            lang: mapLanguage(language)
        });

        return result.lines.join("\n");
    }
}

const mapLanguage = (language: CodeLanguage) : string => {
    return language.toString();
}
