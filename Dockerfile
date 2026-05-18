FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AccountingIntegration.Api/AccountingIntegration.Api.csproj", "AccountingIntegration.Api/"]
COPY ["AccountingIntegration.Application/AccountingIntegration.Application.csproj", "AccountingIntegration.Application/"]
COPY ["AccountingIntegration.Domain/AccountingIntegration.Domain.csproj", "AccountingIntegration.Domain/"]
COPY ["AccountingIntegration.Infrastructure/AccountingIntegration.Infrastructure.csproj", "AccountingIntegration.Infrastructure/"]
RUN dotnet restore "AccountingIntegration.Api/AccountingIntegration.Api.csproj"

COPY . .
WORKDIR "/src/AccountingIntegration.Api"
RUN dotnet build "AccountingIntegration.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccountingIntegration.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountingIntegration.Api.dll"]