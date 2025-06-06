# Prueba Técnica: API de Cat Facts & Gifs

*Solución desarrollada por Michael Hernández - 5 de junio de 2025*

## Descripción del Proyecto

Esta es una aplicación web completa construida con **ASP.NET Core 8** como backend y una interfaz de cliente dinámica con **HTML5, Bootstrap 5 y JavaScript**.

El proyecto cumple con los siguientes requerimientos:
- Una API con 3 endpoints (`/api/fact`, `/api/gif`, `/api/history`).
- Persistencia de datos utilizando **Entity Framework Core** con una base de datos **SQL Server**.
- Una arquitectura de servicios para una correcta separación de responsabilidades.
- Una interfaz de usuario que consume la API para mostrar datos de forma dinámica.
- Funcionalidades avanzadas como carga de contenido al iniciar y refresco selectivo de GIFs.

## Prerrequisitos

Para ejecutar este proyecto, es necesario tener instalado:
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) con la carga de trabajo "Desarrollo de ASP.NET y web".
- SQL Server Express LocalDB (se instala automáticamente con la carga de trabajo anterior).

## Guía de Instalación y Ejecución

### 1. Clonar el Repositorio
```bash
git clone [URL]
```

### 2. Configurar la Clave de API Secreta
La clave de la API de Giphy es necesaria para que la aplicación funcione. Por favor, elija **uno** de los siguientes dos métodos para configurarla.

---
#### **Método A**

Este método utiliza un archivo de configuración específico para el entorno de desarrollo.

1.  En el proyecto de la API, busca el archivo `appsettings.Development.json`. Si no existe, puedes crear uno nuevo.
2.  Abre el archivo y asegúrate de que tenga el siguiente contenido, reemplazando el texto de marcador de posición con la clave real.

    ```
     {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "Giphy": {
        "ApiKey": "voaNIOg1u7ONPbckzWK71C48YqCOkhVP"
      }
    }

    ```

---
#### **Método B**

Este es el flujo de trabajo estándar en la industria para gestionar secretos en desarrollo local, ya que mantiene los secretos completamente fuera de la carpeta del proyecto.

1.  Abre una terminal en la carpeta raíz del proyecto de la API.
2.  Ejecuta los siguientes comandos:

    ```
    dotnet user-secrets init
    dotnet user-secrets set "Giphy:ApiKey" "voaNIOg1u7ONPbckzWK71C48YqCOkhVP"
    ```

### 3. Crear la Base de Datos
Con la clave ya configurada, ejecuta el siguiente comando en la **Consola del Administrador de Paquetes** para crear la base de datos y sus tablas:

```
Update-Database
```

### 4. Ejecutar la Aplicación
Abre la solución (`.sln`) en Visual Studio y presiona `F5` para compilar y ejecutar el proyecto. Se abrirá un navegador web que mostrará la interfaz de usuario funcional.

## Funcionalidades de la Interfaz

- **Carga Automática:** Al iniciar, la aplicación obtiene y muestra un dato curioso y un GIF.
- **Botón de Actualizar Principal Obtiene un nuevo dato curioso y un nuevo GIF, y guarda la búsqueda en el historial.
- **Botón "Refrescar GIF":** Obtiene un GIF diferente para el mismo dato curioso, sin alterar el texto ni el historial.
- **Pestaña "Historial":** Muestra un registro de todas las búsquedas principales realizadas, consultado directamente desde la base de datos.