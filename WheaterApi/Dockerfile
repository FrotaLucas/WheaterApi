# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WheaterApi/WheaterApi.csproj", "WheaterApi/"]
RUN dotnet restore "./WheaterApi/WheaterApi.csproj"
COPY . .
WORKDIR "/src/WheaterApi"
RUN dotnet build "./WheaterApi.csproj" -c $BUILD_CONFIGURATION -o /app/build