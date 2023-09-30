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
| 02 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |
| 03 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |
| 04 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |
| 05 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |
|  | |  |  |
| 06 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |
| 07 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |
| 08 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |
| 09 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |
|  | |  |  |
| 10 | Usuario | [Agregar otro caso de uso] | [Propósito del caso de uso] |

### Criterio de Aceptación

| Criterio n° | Contexto | Evento | Resultado |
|:-----------:|:-----------:|:--------:|:-----------:|
| 01 | En la aplicación de gestión de alumnos | Se hace una solicitud GET a la ruta /Students de la API | Debería recibir una respuesta exitosa con un código de estado 200 (OK). La respuesta incluirá una lista de objetos JSON, donde cada objeto representa a un estudiante. Cada objeto de estudiante en la lista contendrá al menos la siguiente información: ID del estudiante, Nombre completo del estudiante, Edad del estudiante y otros campos relevantes según sea necesario. La lista de estudiantes estará ordenada de alguna manera para facilitar su visualización y búsqueda. La API requerirá autenticación y autorización adecuadas para acceder a la lista de estudiantes, permitiendo solo a usuarios autorizados obtener esta información.|

