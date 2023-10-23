using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Alumnos
    {
        public int Id { get; set; }

        /// <summary>
        /// El nombre del estudiante.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? Nombre { get; set; }

        /// <summary>
        /// El apellido del estudiante.
        /// </summary>
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string? Apellido { get; set; }

        /// <summary>
        /// Número único que identifica al alumno.
        /// </summary>
        [Required(ErrorMessage = "El número de identificación es obligatorio.")]
        [ArgentinaDNI]
        public int NumIdentificacion { get; set; }

        /// <summary>
        /// La fecha de nacimiento del alumno.
        /// </summary>
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// La dirección actual del alumno.
        /// </summary>
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string? Direccion { get; set; }

        /// <summary>
        /// El número de teléfono de contacto del alumno.
        /// </summary>
        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        public string? Telefono { get; set; }

        /// <summary>
        /// La dirección de correo electrónico del alumno.
        /// </summary>
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string? CorreoElectronico { get; set; }

        /// <summary>
        /// El programa académico en el que está inscrito el alumno.
        /// </summary>
        [Required(ErrorMessage = "La carrera es obligatoria.")]
        public string? Carrera { get; set; }

        /// <summary>
        /// El promedio académico del alumno (campo numérico con validación de rango de 1 a 100).
        /// </summary>
        [Required(ErrorMessage = "El promedio es obligatorio.")]
        [Range(1, 100, ErrorMessage = "El promedio debe estar entre 1 y 100.")]
        public decimal Promedio { get; set; }

        /// <summary>
        /// La fecha en que el alumno se matriculó en la institución.
        /// </summary>
        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        public DateTime FechaIngreso { get; set; }
    }
}
