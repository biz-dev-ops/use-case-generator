import { createContainer, BuildResolver, BuildResolverOptions, Constructor, DisposableResolver, Resolver, asClass, AwilixContainer, asFunction, InjectionMode, aliasTo } from "awilix";
import { GetServicesPort, MyServices } from "../ports/GetServices";
import { FsAdapter } from "./FsAdapter";
import { PinoAdapter } from "./PinoAdapter";
import { ArgsAdapter } from "./ArgsAdapter";
import { GenerateUseCaseCodeImpl } from "../domain/GenerateUseCaseCodeImpl";
import { QuickTypeAdapter } from "./QuickTypeAdapter";
import { CodeGenerator } from "./CodeGenerator";
import { JsonSchemaAdapter } from "./JsonSchemaAdapter";

export default class ProductionContainer implements GetServicesPort {
    private readonly container: AwilixContainer<MyServices>;

    constructor() {
        this.container = createContainer<MyServices>({
                injectionMode: InjectionMode.CLASSIC
            })
            .register("generateUseCaseCode", asDisposableClass(GenerateUseCaseCodeImpl).singleton())
            
            .register("generateCodePort", asDisposableClass(CodeGenerator).singleton())
            .register("generateTypePort", asDisposableClass(QuickTypeAdapter).singleton())
            .register("getOptionsPort", asDisposableClass(ArgsAdapter).singleton())
            .register("getUseCaseSchemaPort", asDisposableClass(JsonSchemaAdapter).singleton())
            .register("getUseCaseFilesPort", aliasTo("getFileReferencePort"))
            .register("getFileReferencePort", asDisposableClass(FsAdapter).singleton())
            .register("logMessagePort", asDisposableClass(PinoAdapter).singleton());
    }

    getServices(): MyServices {
        return this.container.cradle;
    }
}

function asDisposableClass<T = {}>(Type: Constructor<T>, opts?: BuildResolverOptions<T>): BuildResolver<T> & DisposableResolver<T> {
    const resolver = asClass<T>(Type, opts);
    const disposableResolver = resolver as DisposableResolver<T>;

    disposableResolver.disposer(async (service) => {
        const asyncDisposable = service as AsyncDisposable;
        if (asyncDisposable) {
            await asyncDisposable[Symbol.asyncDispose]();
            return;
        }

        const disposable = service as Disposable;
        if (disposable) {
            disposable[Symbol.dispose]();
            return;
        }
    });
    return resolver;
}

function asArray<T = {}>(types: string[]): Resolver<T[]> {
    return {
        resolve: (container) => types.map(name => container.resolve<T>(name))
    }
}