# --- Etapa de Compilación (Build Stage) ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copia solo el archivo .csproj para restaurar las dependencias primero.
# Esto aprovecha el caché de Docker si no cambian los paquetes.
COPY *.csproj .
RUN dotnet restore

# Copia el resto del código fuente del proyecto.
COPY . .

# Publica la aplicación.
RUN dotnet publish -c Release -o /app/out --no-restore

# --- Etapa Final (Runtime Stage) ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expone el puerto 80 y configura Kestrel para escuchar en él.
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

# Punto de entrada correcto.
ENTRYPOINT ["dotnet", "perla-metro-users-service.dll"]