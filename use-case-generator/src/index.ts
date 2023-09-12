#! /usr/bin/env node

import ProductionContainer from "./adapters/AwilixAdapter";


const main = async () : Promise<void> => {
    const services = new ProductionContainer().getServices();

    const options = await services.getOptionsPort.getOptions();
    const createUseCode = services.createUseCaseCode;
    createUseCode.handle(options.language, options.source, options.destination);
}

main();