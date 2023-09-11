#! /usr/bin/env node

const process = require("process");
const path = require("path");
const { hideBin } = require("yargs/helpers");
const yargs = require("yargs");
const App = require("./app");

(async () => {
    let app;

    try {
        process.chdir(path.join(process.cwd(), "bin"));

        const args = yargs(hideBin(process.argv))
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
            
            app = new App(args);
            await app.run();
            
    } finally {
        app?.dispose();
    }
})();