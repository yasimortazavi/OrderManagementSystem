# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY Services/Order/Order.API/*.csproj ./Services/Order/Order.API/
COPY Services/Order/Order.Application/*.csproj ./Services/Order/Order.Application/
COPY Services/Order/Order.Infrastructure/*.csproj ./Services/Order/Order.Infrastructure/
COPY BuildingBlocks/*.csproj ./BuildingBlocks/

RUN dotnet restore

COPY . .
WORKDIR /app/Services/Order/Order.API
RUN dotnet publish -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "Order.API.dll"]
