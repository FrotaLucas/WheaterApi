# Est�gio base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Est�gio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WheaterApi/WheaterApi.csproj", "WheaterApi/"]
RUN dotnet restore "WheaterApi/WheaterApi.csproj"
COPY . .
WORKDIR "/src/WheaterApi"
RUN dotnet build "WheaterApi.csproj" -c Release -o /app/build

# Est�gio de publish
FROM build AS publish
RUN dotnet publish "WheaterApi.csproj" -c Release -o /app/publish

# Est�gio final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WheaterApi.dll"]