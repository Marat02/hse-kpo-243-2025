FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KPO.Example.Api/KPO.Example.Api.csproj", "KPO.Example.Api/"]
COPY ["KPO.Example.Infrastructure/KPO.Example.Infrastructure.csproj", "KPO.Example.Infrastructure/"]
COPY ["KPO.Example.Application/KPO.Example.Application.csproj", "KPO.Example.Application/"]
COPY ["KPO.Example/KPO.Example.csproj", "KPO.Example/"]
COPY ["KPO.DDD.Basic/KPO.DDD.Basic.csproj", "KPO.DDD.Basic/"]
COPY ["KPO.Example.Contracts/KPO.Example.Contracts.csproj", "KPO.Example.Contracts/"]
COPY ["KPO.CarPreOrder.Application/KPO.CarPreOrder.Application.csproj", "KPO.CarPreOrder.Application/"]
COPY ["KPO.CarPreOrder.Domain/KPO.CarPreOrder.Domain.csproj", "KPO.CarPreOrder.Domain/"]
RUN dotnet restore "KPO.Example.Api/KPO.Example.Api.csproj"
COPY . .
WORKDIR "/src/KPO.Example.Api"
RUN dotnet build "./KPO.Example.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KPO.Example.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KPO.Example.Api.dll"]
