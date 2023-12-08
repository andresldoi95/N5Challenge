#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApplication1/N5ChallengeWebApi.csproj", "WebApplication1/"]
COPY ["N5ChallengeWebApiApplication/N5ChallengeWebApiApplication.csproj", "N5ChallengeWebApiApplication/"]
COPY ["N5ChallengeWebApiRepository/N5ChallengeWebApiInfrastructure.csproj", "N5ChallengeWebApiRepository/"]
COPY ["N5ChallengeWebApiDomain/N5ChallengeWebApiDomain.csproj", "N5ChallengeWebApiDomain/"]
RUN dotnet restore "./WebApplication1/./N5ChallengeWebApi.csproj"
COPY . .
WORKDIR "/src/WebApplication1"
RUN dotnet build "./N5ChallengeWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./N5ChallengeWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N5ChallengeWebApi.dll"]