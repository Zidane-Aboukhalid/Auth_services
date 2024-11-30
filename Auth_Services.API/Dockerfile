# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:6.0-jammy AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Auth_Services.API/Auth_Services.API.csproj", "Auth_Services.API/"]
COPY ["Auth_Services.Infrastructure/Auth_Services.Infrastructure.csproj", "Auth_Services.Infrastructure/"]
COPY ["Auth_Services.Application/Auth_Services.Application.csproj", "Auth_Services.Application/"]
COPY ["Auth_Services.Domain/Auth_Services.Domain.csproj", "Auth_Services.Domain/"]
RUN dotnet restore "./Auth_Services.API/Auth_Services.API.csproj"
COPY . .
WORKDIR "/src/Auth_Services.API"
RUN dotnet build "./Auth_Services.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Auth_Services.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth_Services.API.dll"]