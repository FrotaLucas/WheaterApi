FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WheaterApi/WheaterApi.csproj", "WheaterApi/"]
COPY ["Wheater.Shared/Wheater.Shared.csproj", "Wheater.Shared/"]
RUN dotnet restore "WheaterApi/WheaterApi.csproj"

COPY . .
WORKDIR "/src/WheaterApi"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WheaterApi.dll"]
