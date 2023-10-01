namespace Data.Entities;
public class Alumnos
{
    public int Id { get; set; }

    /// <summary>
    /// El nombre del estudiante.
    /// </summary>
    public string? Nombre { get; set; }

    /// <summary>
    /// El apellido del estudiante.
    /// </summary>
    public string? Apellido { get; set; }

    /// <summary>
    /// Número único que identifica al alumno.
    /// </summary>
    public int NumIdentificacion { get; set; }

    /// <summary>
    /// La fecha de nacimiento del alumno.
    /// </summary>
    public DateTime FechaNacimiento { get; set; }

    /// <summary>
    /// La dirección actual del alumno.
    /// </summary>
    public string? Direccion { get; set; }

    /// <summary>
    /// El número de teléfono de contacto del alumno.
    /// </summary>
    public string? Telefono { get; set; }

    /// <summary>
    /// La dirección de correo electrónico del alumno.
    /// </summary>
    public string? CorreoElectronico { get; set; }

    /// <summary>
    /// El programa académico en el que está inscrito el alumno.
    /// </summary>
    public string? Carrera { get; set; }

    /// <summary>
    /// El promedio académico del alumno (campo numérico con validación de rango de 1 a 100).
    /// </summary>
    public decimal Promedio { get; set; }

    /// <summary>
    /// La fecha en que el alumno se matriculó en la institución.
    /// </summary>
    public DateTime FechaIngreso { get; set; }
}
