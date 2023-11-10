SpringBoot reference application
--------------------------------
Build it:
```shell
./gradlew clean build
```

Run it:
```shell
./gradlew bootrun
```

Then open Swagger UI: http://localhost:8080/swagger-ui/index.html

Docker it:
```shell
docker build -t example:last -f Dockerfile .
docker run -p 8080:8080 example:last
```