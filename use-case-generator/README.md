# Use-case generator

The code generator parses a YAML file which contains a use-case description. Json-schema is used to specify the use-case parameters and response. The parsed use-case specification is used to generate the use-case interface as well as the parameter and response types.

## Schema

```yaml
name: use case 1
description: a description
parameters:
  param1:
    type: string
  param2:
    $ref: "./param2.yml" 
response:
  $ref: "./response.yml" 
```

## Mapping

A mapping YAML file is created to map the schema type references to the generated code types and namespaces. This mapping file can later be used for exposing the use-case via an adapter implementation.

```yaml
- reference: /data-dictionary/use-cases/my-use-case.yml
  hash: aa0094263c552bb252404fe822394fa5
  namespace: my.project.domain.use-cases
  name: MyUseCase
- reference: /data-dictionary/types/my-type.yml
  hash: 90be3009ab27b06c9bd6d32f68f57ce2
  namespace: my.project.domain.types
  name: MyType
```

## Convention

1. File name is the use-case name;
2. Use-case name can be overwritten by the name property in YAML file.
3. Parameters and response properties are optional.
4. Use-case is a command when there is no response specified;
5. Use-case is a query when a response is specified;
6. Parameters is a key / value collection. The value is a Json-schema type.
7. Response is a Json-schema type.