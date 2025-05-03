FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DL.StartUp/DL.StartUp.csproj", "DL.StartUp/"]
COPY ["DL.Audit/DL.Audit.csproj", "DL.Audit/"]
COPY ["DL.Audit.Models/DL.Audit.Models.csproj", "DL.Audit.Models/"]
COPY ["DL.Core/DL.Core.csproj", "DL.Core/"]
COPY ["DL.Auth/DL.Auth.csproj", "DL.Auth/"]
COPY ["DL.Directories/DL.Directories.csproj", "DL.Directories/"]
COPY ["DL.Migrator/DL.Migrator.csproj", "DL.Migrator/"]
COPY ["DL.QR/DL.QR.csproj", "DL.QR/"]
RUN dotnet restore "DL.StartUp/DL.StartUp.csproj"
COPY . .
WORKDIR "/src/DL.StartUp"
RUN dotnet build "DL.StartUp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DL.StartUp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DL.StartUp.dll"]
