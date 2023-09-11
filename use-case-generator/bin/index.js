#! /usr/bin/env node

const process = require("process");
const path = require("path");
const { hideBin } = require("yargs/helpers");
const yargs = require("yargs");
const { createContainer, asValue, Lifetime } = require("awilix");

const main = async () => {
    let container;

    try {
        process.chdir(path.join(process.cwd(), "bin"));
        const options = parseArgs(getArgs());
        container = initContainer(options);
        
        let app = container.resolve("app");
        await app.run();
        app = null;
    } 
    finally {
        await container?.dispose();
        container = null
    }
};

const initContainer = (options) => createContainer()
        .register("options", asValue(options))
        .loadModules([
            "app.js",
            "utils/*.js"
        ], {
            resolverOptions: {
                lifetime: Lifetime.SINGLETON,
                dispose: async (service) => await service.dispose?.()
            }
        });

    const parseArgs = (args) => ({
        language: args.language,
        source: args.source,
        destination: args.destination,
        loglevel: args.loglevel
    })

    const getArgs = () => 
        yargs(hideBin(process.argv))
        .option("language", {
            alias: [ "lang", "l" ],
            describe: "Define code language to generate.",
            type: "string",
            choices: ["c#", "java"],
            demandOption: true
        })
        .option("source", {
            alias: ["src", "s" ],
            describe: "The source use-case specification file or directory.",
            type: "string",
            demandOption: true
        })
        .option("destination", {
            alias: [ "dst", "d" ], 
            describe: "The destination directory where use-cases need to be genrated.",
            type: "string",
            demandOption: true
        })
        .option("loglevel", {
            alias: "ll",
            describe: "Define the log level.",
            type: "string",
            choices: ["fatal", "error", "warn", "info", "debug", "trace"]
        })
        .argv;

main();