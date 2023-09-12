import { CreateUseCaseCode } from "../use-cases/CreateUseCaseCode";
import { GetFileReferencePort } from "./GetFileReference";
import { GetOptionsPort } from "./GetOptions";
import { GetUseCaseFilesPort } from "./GetUseCaseFiles";
import { GetUseCaseSchemaPort } from "./GetUseCaseSchema";
import { LogMesssagePort } from "./LogMessage";

export interface GetServicesPort {
    getServices() : MyServices;
}

export interface MyServices {
    createUseCaseCode : CreateUseCaseCode
    getFileReferencePort: GetFileReferencePort,
    getUseCaseFilesPort: GetUseCaseFilesPort,
    getUseCaseSchemaPort: GetUseCaseSchemaPort,
    logMessagePort: LogMesssagePort,
    getOptionsPort: GetOptionsPort
}