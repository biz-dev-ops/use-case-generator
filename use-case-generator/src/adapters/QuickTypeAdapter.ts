import { quicktype, InputData, JSONSchemaInput, FetchingJSONSchemaStore } from "quicktype-core";

import { GenerateTypePort } from "../ports/GenerateType";
import { LanguageOption } from "../ports/GetOptions";
import { LogMesssagePort } from "../ports/LogMessage";

export class QuickTypeAdapter implements GenerateTypePort {
    private readonly logger: LogMesssagePort;

    constructor(logMessagePort: LogMesssagePort) {
        this.logger = logMessagePort;
    }

    async generateType(language: LanguageOption, name: string, schema: string): Promise<string> {
        const schemaInput = new JSONSchemaInput(new FetchingJSONSchemaStore());

        await schemaInput.addSource( { 
            name: name, 
            schema: schema
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

const mapLanguage = (language: LanguageOption) : string => {
    return language.toString();
}
