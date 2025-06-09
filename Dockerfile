FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY RestCatalogService.sln .
COPY src/RestCatalogService.WebApi/RestCatalogService.WebApi.csproj src/RestCatalogService.WebApi/

RUN dotnet restore src/RestCatalogService.WebApi/RestCatalogService.WebApi.csproj

COPY . .

RUN dotnet publish \
    src/RestCatalogService.WebApi/RestCatalogService.WebApi.csproj \
    -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /app .

EXPOSE 80
ENTRYPOINT ["dotnet", "RestCatalogService.WebApi.dll"]
