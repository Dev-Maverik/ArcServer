FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 5012

ENV ASPNETCORE_URLS=http://+:5012

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Configuration.API/Configuration.API.csproj", "Configuration.API/"]
RUN dotnet restore "Configuration.API\Configuration.API.csproj"
COPY . .
WORKDIR "/src/Configuration.API"
RUN dotnet build "Configuration.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Configuration.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Configuration.API.dll"]
