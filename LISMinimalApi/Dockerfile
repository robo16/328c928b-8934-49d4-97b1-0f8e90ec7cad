FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["LISMinimalApi/LISMinimalApi.csproj", "LISMinimalApi/"]
RUN dotnet restore "LISMinimalApi/LISMinimalApi.csproj"
COPY . .
WORKDIR "/src/LISMinimalApi"
RUN dotnet build "LISMinimalApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LISMinimalApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LISMinimalApi.dll"]
