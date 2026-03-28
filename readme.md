# 🌐 Taller 1 : Arquitectura de Sistemas
## Servicio de usuarios

## 📌 Integrantes
* Benjamín Miranda O. (21544970-K)

## 📖 Descripción

El proyecto consiste en una webapi en .NET que responde al apartado de manejo y
administración de usuarios para perla metro
---
## Tecnologías
El proyecto utiliza las siguientes tecnologías y herramientas:
- **C#**: Lenguaje de programación.
- **.NET 8**: Framework para construir la webapi.
- **Postgres**: Base de datos para almacenar los usuarios.

## Patrones de Diseño
En la implementación del proyecto se aplicaron diferentes **patrones de diseño** para garantizar la separación de responsabilidades, la reutilización de componentes y la mantenibilidad del sistema.

### DAO (Data Access Object)
El patrón **DAO** permite abstraer y encapsular el acceso a la base de datos, evitando que la lógica de negocio interactúe directamente con las consultas SQL o con la tecnología de persistencia.

### DTO (Data Transfer Object)
El patrón **DTO** se emplea para transportar datos entre las capas de la aplicación sin exponer directamente las entidades del dominio.

### Repository
El patrón **Repository** actúa como un intermediario entre la lógica de negocio y la capa de persistencia, simulando una colección en memoria que abstrae las operaciones sobre la base de datos.

## 

## ⚙️ Requisitos Previos

Asegúrate de tener instalado:
1. [.NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
2. **Git** para clonar el repositorio.
3. **Postgres** Para correr la base de datos

---

## 🚀 Construcción

### 1️⃣ Clonar el Repositorio

Clonar el repositorio utilizando git
```bash
  git clone https://github.com/bxnjadev/perla-metro-users-service
```
### 2️⃣ Ir a la carpeta que contiene el proyecto
```bash
  cd perla-metro-users-service
```
---

### 3️⃣ Configuración del Archivo `appsettings.json`

El archivo `appsettings.json` contiene las configuraciones esenciales para el funcionamiento de la API.  
Asegúrate de que tenga la siguiente estructura:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "default": "<url>"
  }
}

```
### 4️⃣ Migraciones de Base de Datos

Si estás utilizando **Entity Framework** para manejar la base de datos, debes aplicar las migraciones necesarias con los siguientes pasos:

1. **Generar las migraciones**:
   Ejecuta el siguiente comando para crear la migración inicial:
   ```bash
   dotnet ef migrations add InitialCreate
   ```
Este comando generará un archivo de migración que define la estructura de la base de datos.

2. **Aplicar las migraciones para crear la base de datos:**
   Ejecuta el siguiente comando para aplicar la migración y crear la base de datos:
   ```bash
   dotnet ef database update
   ```
---
### 5️⃣ Ejecutar el Proyecto
Una vez completados los pasos anteriores, puedes iniciar el servidor localmente con el siguiente comando:

 ```bash
   dotnet run
  ```