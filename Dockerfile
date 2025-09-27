FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Stage 1: Build
WORKDIR /src

# Copy solution and project files
COPY *.sln ./
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and publish
COPY . .
RUN dotnet publish -c Release -o /out --no-restore

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /out .

ENTRYPOINT ["dotnet", "perla-metro-stations-users.dll"]