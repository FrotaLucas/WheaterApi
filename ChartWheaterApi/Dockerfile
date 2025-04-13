FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ChartWheaterApi/ChartWheaterApi.csproj", "ChartWheaterApi/"]
COPY ["Wheater.Shared/Wheater.Shared.csproj", "Wheater.Shared/"]
RUN dotnet restore "ChartWheaterApi/ChartWheaterApi.csproj"

COPY . .
WORKDIR "/src/ChartWheaterApi"
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
# substitui a base address no index.html ou outro mecanismo via JS, se necessário
ENTRYPOINT ["dotnet", "ChartWheaterApi.dll"]
