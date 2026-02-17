# NewAppi - API REST de Productos
API REST desarrollada en .NET 8 siguiendo principios REST y arquitectura por capas.
Permite gestionar productos mediante operaciones CRUD.


## Tecnologías
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)
- Postman


## Arquitectura
El proyecto sigue una arquitectura por capas:

- Domain: Entidades del dominio
- Application: DTOs y servicios
- Infrastructure: Acceso a datos (EF Core)
- API: Controladores y configuración


## Endpoints principales

| Método | Ruta | Descripción |
|------|------|-------------|
| GET | /api/productos | Listar productos |
| GET | /api/productos/{id} | Obtener producto |
| POST | /api/productos | Crear producto |
| PUT | /api/productos/{id} | Actualizar producto |
| DELETE | /api/productos/{id} | Eliminar producto |


## Documentación
Swagger disponible en:
https://localhost:7195/swagger


## Ejecución
1. Clonar repositorio
2. Configurar cadena de conexión en appsettings.json
3. Ejecutar migraciones
4. Iniciar el proyecto


## Postman

El proyecto incluye una colección Postman para facilitar las pruebas de la API.

📁 Ruta:
postman/NewAppi.postman_collection.json

### Cómo usarla:
1. Abrir Postman
2. Importar colección
3. Ajustar la URL base si es necesario
4. Ejecutar los endpoints disponibles

