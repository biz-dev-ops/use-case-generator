import { GetFileReferencePort } from "./GetFileReference";
import { GetOptionsPort } from "./GetOptions";
import { LogMesssagePort } from "./LogMessage";

export interface GetServicesPort {
    getServices() : MyServices;
}

export interface MyServices {
    getFileReferencePort: GetFileReferencePort,
    logMessagePort: LogMesssagePort,
    getOptionsPort: GetOptionsPort
}