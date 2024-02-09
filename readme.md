# API Rest Tasa de Cambio del Banco Central - Documentación

## Descripción

La API Rest Tasa de Cambio del Banco Central proporciona acceso a la tasa de cambio del banco central de Nicaragua a través del servicios web SOAP. La aplicación descarga la tasa de cambio actualizada del mes en curso, la almacena en una base de datos y proporciona endpoints para acceder a esta información.

## Funcionamiento

1. **Obtención de la Tasa de Cambio Actualizada**: La API recupera la tasa de cambio del mes actual a través de un servicio web SOAP proporcionado por el Banco Central de Nicaragua.

2. **Almacenamiento en la Base de Datos**: Una vez descargada la tasa de cambio del mes, se almacena en la base de datos para su posterior acceso.

3. **Endpoints Disponibles**: La API ofrece endpoints para acceder a la tasa de cambio almacenada en la base de datos.

## Endpoints Disponibles

- **Obtener Tasa de Cambio del Mes Actual**
  - Método: `GET`
  - Ruta: `/api/TasaCambio`
  - Descripción: Este endpoint permite obtener la tasa de cambio del día actual(hoy) almacenada en la base de datos.
  - Respuesta Exitosa:
    - Código de Estado: 200 OK
    - Cuerpo de la Respuesta: Objeto JSON que contiene la tasa de cambio del día corriente.
  - Respuesta de Error:
    - Código de Estado: 404 Not Found
    - Descripción: Si la tasa de cambio del día no se encuentra disponible.

- **Descargar y guardar la Tasa de Cambio por Fecha**
  - Método: `POST`
  - Ruta: `/api/TasaCambio`
  - Descripción: Este endpoint permite obtener y guardar la tasa de cambio del banco central para una fecha específica.
  - Respuesta Exitosa:
    - Código de Estado: 200 OK
    - Cuerpo de la Respuesta: TRUE.
  - Respuesta de Error:
    - Código de Estado: 404 Not Found
    - Descripción: Si la tasa de cambio para la fecha especificada no se encuentra disponible.

## Crear tabla en SQL Server

``` sql
CREATE DATABASE TasaCambioDB;

USE TasaCambioDB;

CREATE TABLE TasaCambio (
    IdTasaCambio UNIQUEIDENTIFIER PRIMARY KEY,
    Fecha DATE,
    TipoCambio FLOAT,
    FechaRegistro DATETIME
);
```


## Diccionario de datos 

| Nombre de la columna | Tipo de datos     | Permite nulos | Descripción                                   |
|----------------------|-------------------|---------------|-----------------------------------------------|
| IdTasaCambio         | UNIQUEIDENTIFIER  | No            | Identificador único de la tasa de cambio      |
| Fecha                | DATE              | Sí            | Fecha de la tasa de cambio                    |
| TipoCambio           | FLOAT             | Sí            | Valor de la tasa de cambio                    |
| FechaRegistro        | DATETIME          | Sí            | Fecha de registro en la base de datos         |

**Clave primaria (PK):** IdTasaCambio

## Tecnologías Utilizadas

- ASP.NET Core: Marco de trabajo utilizado para desarrollar la API REST.
- Entity Framework Core: Herramienta de acceso a datos para interactuar con la base de datos.
- Microsoft SQL Server: Sistema de gestión de bases de datos relacional utilizado para almacenar la tasa de cambio.
- [Servicio Web SOAP](https://servicios.bcn.gob.ni/Tc_Servicio/ServicioTC.asmx): Utilizado para obtener la tasa de cambio actualizada del Banco Central de Nicaragua.

## Recursos Adicionales

- Documentación del Banco Central de Nicaragua para los servicios web SOAP.
- Swagger/OpenAPI para la documentación detallada de la API.


Esta API proporciona una solución eficiente y confiable para acceder a la tasa de cambio del banco central de Nicaragua, facilitando cálculos financieros y análisis económicos.

- ## Licencia

Este proyecto está bajo la [Licencia MIT](https://opensource.org/licenses/MIT) - ver el archivo LICENSE para más detalles.
