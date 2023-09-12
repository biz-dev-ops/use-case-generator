#! /usr/bin/env node

import ProductionContainer from "./adapters/AwilixAdapter";
import { GetServicesPort } from "./ports/GetServices";

const main = async () : Promise<void> => {
    const services = getServicesPort().getServices();

    const options = await services.getOptionsPort.getOptions();
    const createUseCode = services.createUseCaseCode;
    createUseCode.handle(options.language, options.source, options.destination);
}

const getServicesPort = () : GetServicesPort => {
    //TODO: create development, test container linked to environment.
    return new ProductionContainer();
}

main();