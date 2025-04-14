#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["src/Wrcelo.VrumApp.API/Wrcelo.VrumApp.API.csproj", "src/Wrcelo.VrumApp.API/"]
COPY ["src/Wrcelo.VrumApp.Application/Wrcelo.VrumApp.Application.csproj", "src/Wrcelo.VrumApp.Application/"]
COPY ["src/Wrcelo.VrumApp.Core/Wrcelo.VrumApp.Core.csproj", "src/Wrcelo.VrumApp.Core/"]
COPY ["src/Wrcelo.VrumApp.Infra.Data/Wrcelo.VrumApp.Infra.Data.csproj", "src/Wrcelo.VrumApp.Infra.Data/"]
COPY ["src/Wrcelo.VrumApp.Domain/Wrcelo.VrumApp.Domain.csproj", "src/Wrcelo.VrumApp.Domain/"]
RUN dotnet restore "./src/Wrcelo.VrumApp.API/./Wrcelo.VrumApp.API.csproj"
COPY . .
WORKDIR "/src/src/Wrcelo.VrumApp.API"
RUN dotnet build "./Wrcelo.VrumApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "./Wrcelo.VrumApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wrcelo.VrumApp.API.dll"]