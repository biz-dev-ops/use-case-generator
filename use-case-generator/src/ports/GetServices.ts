import { GenerateUseCaseCode } from "../use-cases/GenerateUseCaseCode";
import { GetOptionsPort } from "./GetOptions";

export interface GetServicesPort {
    getServices() : MyServices;
}

export interface MyServices {
    generateUseCaseCode : GenerateUseCaseCode
    getOptionsPort: GetOptionsPort
}