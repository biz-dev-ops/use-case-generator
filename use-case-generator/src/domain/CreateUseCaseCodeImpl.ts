
import { GenerateTypePort } from "../ports/GenerateType";
import { LanguageOption } from "../ports/GetOptions";
import { GetUseCaseFilesPort } from "../ports/GetUseCaseFiles";
import { GetUseCaseModelPort } from "../ports/GetUseCaseModel";
import { CreateUseCaseCode } from "../use-cases/CreateUseCaseCode";
import { LogMesssagePort } from "../ports/LogMessage";

export class CreateUseCaseCodeImpl implements CreateUseCaseCode {
    private readonly getUseCaseModelPort: GetUseCaseModelPort;
    private readonly getUseCaseFilesPort: GetUseCaseFilesPort;
    private readonly generateTypePort: GenerateTypePort;
    private readonly logger: LogMesssagePort;

    constructor(getUseCaseFilesPort: GetUseCaseFilesPort, getUseCaseSchemaPort: GetUseCaseModelPort, generateTypePort: GenerateTypePort, logMessagePort: LogMesssagePort) {
        this.getUseCaseFilesPort = getUseCaseFilesPort;
        this.getUseCaseModelPort = getUseCaseSchemaPort;
        this.generateTypePort = generateTypePort;
        this.logger = logMessagePort;
    }

    async handle(language: LanguageOption, source: string, destination: string): Promise<void> {
        const useCaseFiles = await this.getUseCaseFilesPort.getUseCaseFiles(source);

        useCaseFiles.forEach(async (useCaseFile) => {
            this.logger.info("Generating code for %s", useCaseFile);
            const useCaseModel = await this.getUseCaseModelPort.getUseCaseModel(useCaseFile);
            
            const generated = await useCaseModel.generateCodeFor(language, this.generateTypePort);
        })
    }
}