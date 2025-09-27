# Dockerfile para despliegue en plataformas cloud con .NET 9
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY *.csproj .
RUN dotnet restore

# Copiar el código fuente
COPY . .

# Publicar la aplicación
RUN dotnet publish -c Release -o out

# Imagen de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copiar archivos compilados
COPY --from=build /app/out .

# El puerto será asignado por la plataforma de despliegue
EXPOSE $PORT
ENV ASPNETCORE_URLS=http://+:$PORT

# Punto de entrada (cambia "TuAplicacion.dll" por tu archivo)
CMD ["dotnet run"]