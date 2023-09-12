
import { LanguageOption } from "../ports/GetOptions";
import { GetUseCaseFilesPort } from "../ports/GetUseCaseFiles";
import { GetUseCaseSchemaPort } from "../ports/GetUseCaseSchema";
import { CreateUseCaseCode } from "../use-cases/CreateUseCaseCode";

export class CreateUseCaseCodeImpl implements CreateUseCaseCode {
    private readonly getUseCaseSchemaPort: GetUseCaseSchemaPort;
    private readonly getUseCaseFilesPort: GetUseCaseFilesPort;

    constructor(getUseCaseFilesPort: GetUseCaseFilesPort, getUseCaseSchemaPort: GetUseCaseSchemaPort) {
        this.getUseCaseFilesPort = getUseCaseFilesPort;
        this.getUseCaseSchemaPort = getUseCaseSchemaPort;
    }

    async handle(language: LanguageOption, source: string, destination: string): Promise<void> {
        const useCaseFiles = await this.getUseCaseFilesPort.getUseCaseFiles(source);

        useCaseFiles.forEach(async (useCaseFile) => {
            const useCaseSchema = await this.getUseCaseSchemaPort.getUseCaseSchema(useCaseFile);
            console.log(useCaseSchema);
        })
    }
}