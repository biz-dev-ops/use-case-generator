#! /usr/bin/env node

import ProductionContainer from "./adapters/AwilixAdapter";


const main = async () : Promise<void> => {
    console.log("hello world!");

    const services = new ProductionContainer().getServices();

    const logger = services.logMessagePort;

    logger.info("test!!!!");
}

main();