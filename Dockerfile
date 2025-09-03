# Stage 1: Base image (ASP.NET runtime only)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Stage 2: Build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "MyApi/MyApi.csproj"
RUN dotnet publish "MyApi/MyApi.csproj" -c Release -o /app/publish

# Stage 3: Final container
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyApi.dll"]
