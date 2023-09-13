import { GetUseCaseFilesPort } from "../ports/GetUseCaseFiles";
import { GetUseCaseModelPort, UseCaseModel } from "../ports/GetUseCaseModel";
import { GenerateUseCaseCode as GenerateUseCaseCode } from "../use-cases/GenerateUseCaseCode";
import { LogMesssagePort } from "../ports/LogMessage";
import { GenerateCodePort, InterfaceSchema } from "../ports/GenerateCode";
import { CodeLanguage } from "./Enums";

export class GenerateUseCaseCodeImpl implements GenerateUseCaseCode {
    private readonly getUseCaseSchemaPort: GetUseCaseModelPort;
    private readonly getUseCaseFilesPort: GetUseCaseFilesPort;
    private readonly generateCodePort: GenerateCodePort;
    private readonly logger: LogMesssagePort;

    constructor(getUseCaseFilesPort: GetUseCaseFilesPort, 
        getUseCaseSchemaPort: GetUseCaseModelPort, 
        generateCodePort: GenerateCodePort,
        logMessagePort: LogMesssagePort
    ) {
        this.getUseCaseFilesPort = getUseCaseFilesPort;
        this.getUseCaseSchemaPort = getUseCaseSchemaPort;
        this.generateCodePort = generateCodePort;
        this.logger = logMessagePort;
    }

    async generateUseCaseCode(language: CodeLanguage, source: string, destination: string): Promise<void> {
        const useCaseFiles = await this.getUseCaseFilesPort.getUseCaseFiles(source);

        const useCaseModels = await Promise.all(
            useCaseFiles.map(async (useCaseFile) => await this.getUseCaseSchemaPort.getUseCaseModel(useCaseFile))
        );

        const genratedCodes = await this.generateCodePort.generateCode(language, useCaseModels.map((useCaseModel) => map(useCaseModel)));

        //Todo save code to disk.
    }
}

const map = (schema: UseCaseModel) : InterfaceSchema => {
    return new InterfaceSchema(schema.name, schema.description, schema.parameters, schema.response);
}
