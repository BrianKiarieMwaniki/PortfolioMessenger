#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet build -c Release -o /app/build

# Build and publish a release
RUN dotnet publish -c Release -o /app/out

# Enable HTTPS redirection
ENV ASPNETCORE_URLS="http://+:80;https://+:443"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="Test1234!"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/cert.pfx

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
COPY ["cert.pfx", "/https/cert.pfx"]
ENTRYPOINT ["dotnet", "PortfolioMessenger.Api.dll"]
