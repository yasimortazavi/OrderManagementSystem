# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore
COPY *.sln .
COPY Services/Customer/Customer.API/*.csproj ./Services/Customer/Customer.API/
COPY Services/Customer/Customer.Application/*.csproj ./Services/Customer/Customer.Application/
COPY Services/Customer/Customer.Infrastructure/*.csproj ./Services/Customer/Customer.Infrastructure/
COPY BuildingBlocks/*.csproj ./BuildingBlocks/

RUN dotnet restore

# Copy everything and build
COPY . .
WORKDIR /app/Services/Customer/Customer.API
RUN dotnet publish -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "Customer.API.dll"]
