FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 5011

ENV ASPNETCORE_URLS=http://+:5011

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Arc.Gateway/Arc.Gateway.csproj", "Arc.Gateway/"]
RUN dotnet restore "Arc.Gateway\Arc.Gateway.csproj"
COPY . .
WORKDIR "/src/Arc.Gateway"
RUN dotnet build "Arc.Gateway.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Arc.Gateway.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Arc.Gateway.dll"]
