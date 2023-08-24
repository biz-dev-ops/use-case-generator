# Use case generator

The generator parses a YAML file which contain a use-case description. Json-schema is used to specify the use-case parameters.

To support use-case first development: first create the use specification and secondly create an Open API specification which references the use-case parameters. 

```yaml
name: use case 1
description: a description
parameters:
  - title: param1
    type: string
  - $ref: "./param2.yml" 
```

## Requirements

* Support recursive references;
* Use open-source model generators if possible;
* Use open-source API generators if possible;
* Support hexagonal architecture;
* Create use-cases and models in domain module;
* Expose use-cases in API adapter module;
* Create best practice Java code;
* Create best practice C# code;
* Support easy code language extension;
* Support easy template overrides;