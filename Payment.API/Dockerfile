# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY Services/Payment/Payment.API/*.csproj ./Services/Payment/Payment.API/
COPY Services/Payment/Payment.Application/*.csproj ./Services/Payment/Payment.Application/
COPY Services/Payment/Payment.Infrastructure/*.csproj ./Services/Payment/Payment.Infrastructure/
COPY BuildingBlocks/*.csproj ./BuildingBlocks/

RUN dotnet restore

COPY . .
WORKDIR /app/Services/Payment/Payment.API
RUN dotnet publish -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "Payment.API.dll"]
