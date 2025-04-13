# Estágio de build
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Wrcelo.VrumApp.API/Wrcelo.VrumApp.API.csproj", "src/Wrcelo.VrumApp.API/"]
RUN dotnet restore "src/Wrcelo.VrumApp.API/Wrcelo.VrumApp.API.csproj"
COPY . .
WORKDIR "/src/src/Wrcelo.VrumApp.API"
RUN dotnet build "Wrcelo.VrumApp.API.csproj" -c Release -o /app/build

# Estágio de publish
FROM build AS publish
RUN dotnet publish "Wrcelo.VrumApp.API.csproj" -c Release -o /app/publish

# Estágio final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wrcelo.VrumApp.API.dll"]
