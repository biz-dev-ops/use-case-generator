import { GetUseCaseFilesPort } from "../ports/GetUseCaseFiles";
import { GetUseCaseModelPort, UseCaseModel } from "../ports/GetUseCaseModel";
import { GenerateUseCaseCode as GenerateUseCaseCode } from "../use-cases/GenerateUseCaseCode";
import { LogMesssagePort } from "../ports/LogMessage";
import { GenerateTypeCodePort, InterfaceSchema } from "../ports/GenerateTypeCode";
import { CodeLanguage } from "./Enums";

export class GenerateUseCaseCodeImpl implements GenerateUseCaseCode {
    private readonly getUseCaseSchemaPort: GetUseCaseModelPort;
    private readonly getUseCaseFilesPort: GetUseCaseFilesPort;
    private readonly generateCodePort: GenerateTypeCodePort;
    private readonly logger: LogMesssagePort;

    constructor(getUseCaseFilesPort: GetUseCaseFilesPort, 
        getUseCaseSchemaPort: GetUseCaseModelPort, 
        generateCodePort: GenerateTypeCodePort,
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
            useCaseFiles.map(async (useCaseFile) => 
                await this.getUseCaseSchemaPort.getUseCaseModel(useCaseFile)
            )
        );

        const generatedUseCases = await this.generateCodePort.generateTypeCode(
            language, 
            useCaseModels.map((useCaseModel) => 
                new InterfaceSchema(
                    "todo namespace",
                    useCaseModel.name, 
                    useCaseModel.description,
                    useCaseModel.parameters, 
                    useCaseModel.response
                )
            )
        );

        //Todo save code to disk.
    }
}
