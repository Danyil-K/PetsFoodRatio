# Use the official .NET 9 runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["PetsFoodRatio.Api/PetsFoodRatio.Api.csproj", "PetsFoodRatio.Api/"]
COPY ["PetsFoodRatio.Application/PetsFoodRatio.Application.csproj", "PetsFoodRatio.Application/"]
COPY ["PetsFoodRatio.Infrastructure/PetsFoodRatio.Infrastructure.csproj", "PetsFoodRatio.Infrastructure/"]
COPY ["PetsFoodRatio.Domain/PetsFoodRatio.Domain.csproj", "PetsFoodRatio.Domain/"]

RUN dotnet restore "PetsFoodRatio.Api/PetsFoodRatio.Api.csproj"
COPY . .
WORKDIR "/src/PetsFoodRatio.Api"
RUN dotnet build "PetsFoodRatio.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetsFoodRatio.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetsFoodRatio.Api.dll"]
