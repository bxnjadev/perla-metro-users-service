# --- Etapa de Compilación (Build Stage) ---
# Usa la imagen del SDK de .NET 8 para compilar la aplicación.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copia los archivos del proyecto y restaura las dependencias.
# Esto aprovecha el caché de Docker para acelerar las compilaciones.
COPY perla-metro-users-service/*.csproj ./perla-metro-users-service/
RUN dotnet restore ./perla-metro-users-service/perla-metro-users-service.csproj

# Copia el resto del código fuente y publica la aplicación.
COPY . .
WORKDIR "/source/perla-metro-users-service"
RUN dotnet publish -c Release -o /app/out --no-restore

# --- Etapa Final (Runtime Stage) ---
# Usa la imagen de runtime de ASP.NET 8, que es más ligera y segura.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expone el puerto 80. Render conectará su tráfico a este puerto.
EXPOSE 80
# La siguiente variable de entorno es crucial. Le dice a Kestrel que escuche en el puerto 80
# en todas las interfaces de red ('+'). Esto reemplaza tu configuración de Kestrel en appsettings.json.
ENV ASPNETCORE_URLS=http://+:80

# Punto de entrada correcto para ejecutar tu aplicación.
ENTRYPOINT ["dotnet", "perla-metro-users-service.dll"]