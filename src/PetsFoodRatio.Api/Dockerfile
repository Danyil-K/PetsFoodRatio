# Use the official .NET 9 runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files first for better caching
COPY ["src/PetsFoodRatio.Api/PetsFoodRatio.Api.csproj", "src/PetsFoodRatio.Api/"]
COPY ["src/PetsFoodRatio.Application/PetsFoodRatio.Application.csproj", "src/PetsFoodRatio.Application/"]
COPY ["src/PetsFoodRatio.Infrastructure/PetsFoodRatio.Infrastructure.csproj", "src/PetsFoodRatio.Infrastructure/"]
COPY ["src/PetsFoodRatio.Domain/PetsFoodRatio.Domain.csproj", "src/PetsFoodRatio.Domain/"]

# Restore dependencies
RUN dotnet restore "src/PetsFoodRatio.Api/PetsFoodRatio.Api.csproj"

# Copy source code
COPY . .
WORKDIR "/src/src/PetsFoodRatio.Api"

# Build the application
RUN dotnet build "PetsFoodRatio.Api.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "PetsFoodRatio.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage/image
FROM base AS final
WORKDIR /app

# Copy published app
COPY --from=publish /app/publish .

# Create non-root user for security
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

# Set environment variables for AWS
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "PetsFoodRatio.Api.dll"]
