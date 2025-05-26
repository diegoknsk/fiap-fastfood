# Etapa 1: build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copia tudo para build
COPY . .

# Restaura as dependências
    RUN dotnet restore ./Adapters/Primary/FastFood.Migrator/FastFood.Migrator.csproj

# Publica o projeto
RUN dotnet publish ./Adapters/Primary/FastFood.Migrator/FastFood.Migrator.csproj -c Release -o /out \
    /p:CopyOutputSymbolsToPublishDirectory=false \
    /p:CopyOutputXmlDocumentationToPublishDirectory=false

# Etapa 2: imagem final para execução
FROM mcr.microsoft.com/dotnet/runtime:8.0

WORKDIR /app

COPY --from=build /out ./

# (opcional) reforço de cópia do appsettings.json se necessário
COPY ./Adapters/Primary/FastFood.Migrator/appsettings.json ./appsettings.json

ENTRYPOINT ["dotnet", "FastFood.Migrator.dll"]