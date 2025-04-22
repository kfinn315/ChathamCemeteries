# Chatham Cemeteries

Based on kawser2133's 'web-api-project' ``https://github.com/kawser2133/web-api-project``

```sh
docker build -t chatham-cem-eb -t latest .  
docker run -itp 5000:80 chatham-cem-eb:latest
```

https://docs.docker.com/get-started/docker-concepts/running-containers/publishing-ports/
https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/endpoints?view=aspnetcore-8.0
https://github.com/dotnet/dotnet-docker/blob/main/README.aspnet.md
https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/docker-quickstart.html#docker-quickstart-run-local
https://stackoverflow.com/questions/64557885/how-to-include-class-library-reference-into-docker-file/77592431#77592431

```sh
eb init -p docker chatham-cem -r us-east-2
eb create chatham-cem --single
eb open
eb terminate
```