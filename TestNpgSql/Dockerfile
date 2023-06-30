FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestNpgSql/TestNpgSql.csproj", "TestNpgSql/"]
RUN dotnet restore "TestNpgSql/TestNpgSql.csproj"
COPY . .
WORKDIR "/src/TestNpgSql"
RUN dotnet build "TestNpgSql.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestNpgSql.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestNpgSql.dll"]
