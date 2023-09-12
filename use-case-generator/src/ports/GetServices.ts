import { CreateUseCaseCode } from "../use-cases/CreateUseCaseCode";
import { GetOptionsPort } from "./GetOptions";

export interface GetServicesPort {
    getServices() : MyServices;
}

export interface MyServices {
    createUseCaseCode : CreateUseCaseCode
    getOptionsPort: GetOptionsPort
}