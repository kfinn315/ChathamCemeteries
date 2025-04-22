FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj files and restore as distinct layers
COPY "Project.API/*.csproj" "Project.API/"
COPY "Project.Core/*.csproj" "Project.Core/"
COPY "Project.Infrastructure/*.csproj" "Project.Infrastructure/"
RUN dotnet restore "Project.API/Project.API.csproj"

# copy and build app and libraries
COPY "Project.API/" "Project.API/"
COPY "Project.Core/" "Project.Core/"
COPY "Project.Infrastructure/" "Project.Infrastructure/"
WORKDIR "/source/Project.API"
RUN dotnet publish -o /publish

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
COPY --from=build /publish /app
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["./Project.API"]