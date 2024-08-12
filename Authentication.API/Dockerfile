FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 5013

ENV ASPNETCORE_URLS=http://+:5013

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Authentication.API/Authentication.API.csproj", "Authentication.API/"]
RUN dotnet restore "Authentication.API\Authentication.API.csproj"
COPY . .
WORKDIR "/src/Authentication.API"
RUN dotnet build "Authentication.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Authentication.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authentication.API.dll"]
