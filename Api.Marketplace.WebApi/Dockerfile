#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Api.Marketplace.WebApi/Api.Marketplace.WebApi.csproj", "Api.Marketplace.WebApi/"]
COPY ["Api.Marketplace.Application/Api.Marketplace.Application.csproj", "Api.Marketplace.Application/"]
COPY ["Api.Marketplace.Domain/Api.Marketplace.Domain.csproj", "Api.Marketplace.Domain/"]
COPY ["Api.Marketplace.Persistence/Api.Marketplace.Persistence.csproj", "Api.Marketplace.Persistence/"]
RUN dotnet restore "./Api.Marketplace.WebApi/./Api.Marketplace.WebApi.csproj"
COPY . .
WORKDIR "/src/Api.Marketplace.WebApi"
RUN dotnet build "./Api.Marketplace.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.Marketplace.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Marketplace.WebApi.dll"]