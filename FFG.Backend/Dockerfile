#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Presentation/FFG.Presentation/FFG.Presentation.csproj", "src/Presentation/FFG.Presentation/"]
COPY ["src/Application/FFG.Application/FFG.Application.csproj", "src/Application/FFG.Application/"]
COPY ["src/Application/FFG.Application.Abstractions/FFG.Application.Abstractions.csproj", "src/Application/FFG.Application.Abstractions/"]
COPY ["src/Application/FFG.Application.Models/FFG.Application.Models.csproj", "src/Application/FFG.Application.Models/"]
COPY ["src/Application/FFG.Application.Contracts/FFG.Application.Contracts.csproj", "src/Application/FFG.Application.Contracts/"]
COPY ["src/Infrastructure/FFG.Infrastructure.DataAccess/FFG.Infrastructure.DataAccess.csproj", "src/Infrastructure/FFG.Infrastructure.DataAccess/"]
COPY ["src/Migrations/FFG.Migrations.PostgreSql/FFG.Migrations.PostgreSql.csproj", "src/Migrations/FFG.Migrations.PostgreSql/"]
COPY ["src/Migrations/FFG.Migrations.Sqlite/FFG.Migrations.Sqlite.csproj", "src/Migrations/FFG.Migrations.Sqlite/"]
RUN dotnet restore "./src/Presentation/FFG.Presentation/./FFG.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Presentation/FFG.Presentation"
RUN dotnet build "./FFG.Presentation.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FFG.Presentation.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FFG.Presentation.dll"]