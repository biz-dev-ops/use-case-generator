import { createContainer, BuildResolver, BuildResolverOptions, Constructor, DisposableResolver, Resolver, asClass, AwilixContainer, asFunction, InjectionMode, aliasTo } from "awilix";
import { GetServicesPort, MyServices } from "../ports/GetServices";
import { FsAdapter } from "./FsAdapter";
import { PinoAdapter } from "./PinoAdapter";
import { ArgsAdapter } from "./ArgsAdapter";
import { CreateUseCaseCodeImpl } from "../domain/CreateUseCaseCodeImpl";
import { GetUseCaseModelPortImpl } from "../ports/GetUseCaseModel";
import { QuickTypeAdapter } from "./QuickTypeAdapter";

export default class ProductionContainer implements GetServicesPort {
    private container: AwilixContainer<MyServices>;

    constructor() {
        this.container = createContainer<MyServices>({
                injectionMode: InjectionMode.CLASSIC
            })
            .register("createUseCaseCode", asDisposableClass(CreateUseCaseCodeImpl).singleton())
            .register("generateTypePort", asDisposableClass(QuickTypeAdapter).singleton())
            .register("getOptionsPort", asDisposableClass(ArgsAdapter).singleton())
            .register("getUseCaseSchemaPort", asDisposableClass(GetUseCaseModelPortImpl).singleton())
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