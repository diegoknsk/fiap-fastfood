# Etapa 1: build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY . .

    RUN dotnet restore ./Adapters/Primary/FastFood.Api/FastFood.Api.csproj
#if Verficiar depois oq sao esses parametros adicionais
RUN dotnet publish ./Adapters/Primary/FastFood.Api/FastFood.Api.csproj -c Release -o /app/publish \
    /p:CopyOutputSymbolsToPublishDirectory=false \
    /p:CopyOutputXmlDocumentationToPublishDirectory=false

# Etapa 2: imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80


    EXPOSE 80

ENTRYPOINT ["dotnet", "FastFood.Api.dll"]