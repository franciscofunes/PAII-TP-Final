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
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "El nombre no debe contener caracteres especiales.")]
        public string? Nombre { get; set; }

        /// <summary>
        /// El apellido del estudiante.
        /// </summary>
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "El apellido no debe contener caracteres especiales.")]
        public string? Apellido { get; set; }

        /// <summary>
        /// Número único que identifica al alumno.
        /// </summary>
        [Required(ErrorMessage = "El número de identificación es obligatorio.")]
        [ArgentinaDNI]
        public int NumIdentificacion { get; set; }

        /// <summary>
        /// La fecha de nacimiento del alumno. (Formato válido: 1990-10-15)
        /// </summary>
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "El formato de fecha no es válido.")]
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// La dirección actual del alumno.
        /// </summary>
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [RegularExpression(@"^[A-Za-z0-9\s]+ \d+$", ErrorMessage = "El formato de la dirección no es válido. Debe ser 'Gallo 865' o 'Avenida Cordoba 1234'.")]
        public string? Direccion { get; set; }

        /// <summary>
        /// El número de teléfono de contacto del alumno. (Ejemplo válido: 1131127022)
        /// </summary>
        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [RegularExpression(@"^\d{8,15}$", ErrorMessage = "El número de teléfono no es válido.")]
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
        /// La fecha en que el alumno se matriculó en la institución. (Formato válido: 2023-10-01)
        /// </summary>
        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "El formato de fecha no es válido.")]
        public DateTime FechaIngreso { get; set; }
    }
}
