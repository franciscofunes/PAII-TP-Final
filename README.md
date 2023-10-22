# Trabajo Practico Principal

## Descripción General

Este proyecto consiste en la creación de un sistema para la administración de una entidad importante dentro de un dominio de aplicación elegido. El sistema permitirá realizar las operaciones de Alta, Baja y Modificación (ABM) de esta entidad. A continuación, se presentan ejemplos de posibles entidades dentro de diferentes dominios:

1) Productos: Dominio Sistema de Ventas.
2) Vehículos: Dominio Sistema de Mantenimiento de Autos.
3) Facturas: Dominio Sistema de Facturación.
4) [Agregar más ejemplos según sea necesario].

## Requerimientos Funcionales

El sistema deberá cumplir con los siguientes requisitos funcionales:

1. Dar de alta elementos de esa entidad.
2. Actualizar elementos y sus campos.
3. Eliminar elementos de esa entidad.
4. Listar o presentar todos los elementos de esa entidad en pantalla, con un buscador que permita buscar utilizando al menos dos campos diferentes.

## Requisitos de Diseño - Consideraciones Técnicas

Para el diseño y la implementación del sistema, se deben tener en cuenta las siguientes consideraciones técnicas:

- La entidad principal debe tener al menos 10 campos.
- Al menos un campo debe ser de tipo lista de selección (combo).
- Al menos un campo debe ser de tipo numérico, con un rango válido de 1 a 1000 (validación de rango).
- Se debe realizar una validación de campos según sea necesario.
- La aplicación debe incluir cobertura de pruebas unitarias.
- Se recomienda utilizar algún patrón de diseño que se explicará en clase.

## Requerimiento Funcional Adicional Deseable

Además de la entidad principal, se sugiere agregar una entidad de relación y desarrollar la funcionalidad para dar de alta esta nueva entidad y asociarla a la entidad principal. Por ejemplo, si la entidad principal es "Provincia", una posible entidad de relación podría ser "Localidades". Esto requerirá el desarrollo del alta de localidades y la asociación con la provincia correspondiente.

## Documentación

Para el proyecto, se debe proporcionar la siguiente documentación:

- **README**: Este archivo con la descripción del proyecto y sus requisitos.
- **Diagramas**: Diagramas de diseño, si es necesario.
- **Colección Postman**: Colección de casos de uso de la API, si corresponde.
- **Documentación con Swagger/OpenAPI**: En caso de que el proyecto implique una API.

## Ejecución del Proyecto

[Instrucciones para ejecutar y configurar el proyecto, si corresponde.]

**Nota:** Asegúrese de mantener esta documentación actualizada a medida que avance en el proyecto. Puede agregar más secciones según sea necesario para proporcionar información adicional sobre el proyecto.

## Nuestra Elección y Fundamentos para Realizar el TP

El equipo Nº 1 ha elegido la entidad principal "Alumno" en el dominio de una institución educativa.

**Dominio de la Entidad Principal "Alumno":** Sistema de Gestión Académica.

**Campos de la Entidad "Alumno":**

Para la entidad "Alumno", se definirán al menos 10 campos que son relevantes para la gestión académica y administrativa. Estos campos pueden incluir, entre otros:

1. **Nombre:** El nombre del estudiante.
2. **Apellido:** El apellido del estudiante.
3. **Número de Identificación:** Un número único que identifica al alumno.
4. **Fecha de Nacimiento:** La fecha de nacimiento del alumno.
5. **Dirección:** La dirección actual del alumno.
6. **Teléfono:** El número de teléfono de contacto del alumno.
7. **Correo Electrónico:** La dirección de correo electrónico del alumno.
8. **Carrera:** El programa académico en el que está inscrito el alumno (campo de tipo lista de selección).
9. **Promedio:** El promedio académico del alumno (campo numérico con validación de rango de 1 a 100).
10. **Fecha de Ingreso:** La fecha en que el alumno se matriculó en la institución.

   - El campo "Carrera" es de tipo lista de selección y permitirá seleccionar la carrera en la que está inscrito el alumno.

**Entidad de Relación Adicional:**

Como requisito funcional adicional deseable, se sugiere agregar una entidad de relación llamada "Inscripciones". Esta entidad permitirá gestionar la asociación entre alumnos y los cursos o asignaturas a los que están inscritos.

**Dominio de la Entidad de Relación:** El dominio de la entidad de relación estará relacionado con la oferta académica de la institución y la inscripción de los estudiantes en cursos o asignaturas.

Estos detalles proporcionan una visión más completa de la elección de la entidad "Alumno" y cómo se relaciona con el dominio de la aplicación, los campos necesarios y la entidad de relación. Puede personalizar este texto según sea necesario.


### Casos de Uso
    
| N°  | Como    | Quiero                   | Para                           |
|:---:|:-------:|:-------------------------:|:-----------------------------:|
| 01 | Usuario | Obtener todos los estudiantes | Obtener una lista de todos los estudiantes registrados en el sistema. |
|  | |  |  |
| 02 | Usuario | Agregar un estudiante | Actualizar la lista de los estudiantes registrados en el sistema. |
| 03 | Usuario | Modificar datos de un estudiante | Actualizar la información del estudiante en cuestión. |
| 04 | Usuario | Eliminar un estudiante | Actualizar la lista de los estudiantes registrados en el sistema. |
| 05 | Usuario | Crear o Modifcar un estudiante | Añadir un nuevo estudiante al sistema con la información requerida. Las validaciones en el backend garantizarán que los datos del estudiante son correctos y válidos antes de su inserción en la base de datos. |
| 06 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |
| 07 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |
| 08 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |
| 09 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |
|  | |  |  |
| 10 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |

### Criterios de Aceptación

| Criterio N° | Contexto | Evento | Resultado |
|:-----------:|:-----------:|:--------:|:-----------:|
| 01 | En la aplicación de gestión de alumnos | Se hace una solicitud GET a la ruta /Alumnos de la API | Debería recibir una respuesta exitosa con un código de estado 200 (OK) si la solicitud se procesa correctamente y la lista de estudiantes se devuelve según lo especificado. La respuesta incluirá una lista de objetos JSON, donde cada objeto representa a un estudiante. Cada objeto de estudiante en la lista contendrá al menos la siguiente información: ID del estudiante, Nombre completo del estudiante, Edad del estudiante y otros campos relevantes según sea necesario. La lista de estudiantes estará ordenada de alguna manera para facilitar su visualización y búsqueda. Si ocurren errores al procesar la solicitud, como un problema interno en el servidor o una solicitud mal formada, la API deberá devolver el código de estado apropiado (por ejemplo, 500 Error interno del servidor o 400 Solicitud incorrecta) junto con mensajes de error descriptivos para ayudar a identificar y solucionar el problema. La API debe manejar de manera adecuada cualquier situación inesperada y proporcionar información útil en caso de errores.|
| 02 | En la aplicación de gestión de alumnos | Se hace una solicitud PUT a la ruta /Alumnos/{ID} de la API | Debería ser posible actualizar los campos de la entidad estudiante identificado por su ID. La solicitud PUT deberá incluir los datos actualizados del estudiante en formato JSON. La API deberá validar y procesar la solicitud correctamente, actualizando los campos especificados del estudiante en la base de datos. Se debe devolver una respuesta exitosa con un código de estado 200 (OK) o un código de estado 204 (No Content) si la actualización se realiza con éxito. La API deberá manejar errores y devolver un código de estado adecuado en caso de fallos, como 404 (No encontrado) si no se encuentra el estudiante con el ID proporcionado o 400 (Solicitud incorrecta) si los datos proporcionados son inválidos o incompletos. La actualización de campos debe reflejarse correctamente en la base de datos y en futuras solicitudes GET para obtener información actualizada del estudiante.|
| 03 | En la aplicación de gestión de alumnos | Se hace una solicitud POST a la ruta /Alumnos de la API | Debería ser posible crear un nuevo estudiante en la base de datos mediante la API. La API debe validar los datos proporcionados según las reglas definidas en la entidad. Si los datos son validos: La API debe devolver una respuesta exitosa con un código de estado 201 (Created). El cuerpo de la respuesta debe contener una representación del nuevo estudiante creado. La base de datos debe reflejar la creación del nuevo estudiante con un ID asignado. Si los datos son invalidos o la creación falla: La API debe devolver un código de estado 400 (Solicitud incorrecta) o 422 (Entidad no procesable) si los datos proporcionados son invalidos o incompletos. La respuesta debe incluir detalles sobre los errores de validación en el cuerpo de la respuesta para que el cliente pueda corregirlos. No se debe realizar ninguna operación en la base de datos si los datos son inválidos. La API debe manejar errores y devolver un código de estado adecuado en caso de fallos de servidor.
| 04 | En la aplicación de gestión de alumnos | Se hace una solicitud DELETE a la ruta /Alumnos/{ID} de la API | Debería ser posible eliminar un estudiante cargado en la base de datos mediante la API. La API deberá validar los datos verificando la existencia del registro, arrojando un código de estado 404 (Not Found) en caso de no encontrarlo, un código de estado 204 (No Content) en caso de eliminar exitosamente el registro, y un código de estado 500 (Que tendrá un mensaje de error personalizado) en caso de fallar la eliminación. No se debe realizar ninguna operación en la base de datos si los datos son inválidos. La API debe manejar errores y devolver un código de estado adecuado en caso de fallos de servidor.
| 05 | En la aplicación de gestión de alumnos | En las operaciones en las que se crea un estudiante | Se agregarán validaciones en el backend de los siguientes campos: Nombre, Apellido, NumIdentificacion, FechaNacimiento, Direccion, Telefono, CorreoElectronico, Carrera y Promedio. Estas validaciones garantizarán la integridad y validez de los datos antes de su inserción en la base de datos. Las validaciones incluirán la comprobación de tipos de datos, restricciones de longitud, unicidad de identificadores, y otros criterios relevantes para la entidad del estudiante. Esto ayudará a prevenir la inserción de datos incorrectos o inconsistentes en la base de datos, mejorando la calidad y confiabilidad de la información.

## Instalación de Paquetes

Para ejecutar este proyecto, es necesario instalar algunas bibliotecas y paquetes de .NET. Puedes utilizar la interfaz de línea de comandos de .NET (CLI) para instalarlos. A continuación, se muestran los comandos para instalar los paquetes necesarios:

### Entity Framework Core y SQL Server

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

## Ejecutar la solución

```bash
dotnet watch run
```
