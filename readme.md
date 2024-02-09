# API Rest Tasa de Cambio del Banco Central - Documentaci�n

## Descripci�n

La API Rest Tasa de Cambio del Banco Central proporciona acceso a la tasa de cambio del banco central de Nicaragua a trav�s del servicios web SOAP. La aplicaci�n descarga la tasa de cambio actualizada del mes en curso, la almacena en una base de datos y proporciona endpoints para acceder a esta informaci�n.

## Funcionamiento

1. **Obtenci�n de la Tasa de Cambio Actualizada**: La API recupera la tasa de cambio del mes actual a trav�s de un servicio web SOAP proporcionado por el Banco Central de Nicaragua.

2. **Almacenamiento en la Base de Datos**: Una vez descargada la tasa de cambio del mes, se almacena en la base de datos para su posterior acceso.

3. **Endpoints Disponibles**: La API ofrece endpoints para acceder a la tasa de cambio almacenada en la base de datos.

## Endpoints Disponibles

- **Obtener Tasa de Cambio del Mes Actual**
  - M�todo: `GET`
  - Ruta: `/api/TasaCambio`
  - Descripci�n: Este endpoint permite obtener la tasa de cambio del d�a actual(hoy) almacenada en la base de datos.
  - Respuesta Exitosa:
    - C�digo de Estado: 200 OK
    - Cuerpo de la Respuesta: Objeto JSON que contiene la tasa de cambio del d�a corriente.
  - Respuesta de Error:
    - C�digo de Estado: 404 Not Found
    - Descripci�n: Si la tasa de cambio del d�a no se encuentra disponible.

- **Descargar y guardar la Tasa de Cambio por Fecha**
  - M�todo: `POST`
  - Ruta: `/api/TasaCambio`
  - Descripci�n: Este endpoint permite obtener y guardar la tasa de cambio del banco central para una fecha espec�fica.
  - Respuesta Exitosa:
    - C�digo de Estado: 200 OK
    - Cuerpo de la Respuesta: TRUE.
  - Respuesta de Error:
    - C�digo de Estado: 404 Not Found
    - Descripci�n: Si la tasa de cambio para la fecha especificada no se encuentra disponible.

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

| Nombre de la columna | Tipo de datos     | Permite nulos | Descripci�n                                   |
|----------------------|-------------------|---------------|-----------------------------------------------|
| IdTasaCambio         | UNIQUEIDENTIFIER  | No            | Identificador �nico de la tasa de cambio      |
| Fecha                | DATE              | S�            | Fecha de la tasa de cambio                    |
| TipoCambio           | FLOAT             | S�            | Valor de la tasa de cambio                    |
| FechaRegistro        | DATETIME          | S�            | Fecha de registro en la base de datos         |

**Clave primaria (PK):** IdTasaCambio

## Tecnolog�as Utilizadas

- ASP.NET Core: Marco de trabajo utilizado para desarrollar la API REST.
- Entity Framework Core: Herramienta de acceso a datos para interactuar con la base de datos.
- Microsoft SQL Server: Sistema de gesti�n de bases de datos relacional utilizado para almacenar la tasa de cambio.
- [Servicio Web SOAP](https://servicios.bcn.gob.ni/Tc_Servicio/ServicioTC.asmx): Utilizado para obtener la tasa de cambio actualizada del Banco Central de Nicaragua.

## Recursos Adicionales

- Documentaci�n del Banco Central de Nicaragua para los servicios web SOAP.
- Swagger/OpenAPI para la documentaci�n detallada de la API.


Esta API proporciona una soluci�n eficiente y confiable para acceder a la tasa de cambio del banco central de Nicaragua, facilitando c�lculos financieros y an�lisis econ�micos.

- ## Licencia

Este proyecto est� bajo la [Licencia MIT](https://opensource.org/licenses/MIT) - ver el archivo LICENSE para m�s detalles.
