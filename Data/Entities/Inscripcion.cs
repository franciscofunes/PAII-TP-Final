using System;
using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Data.Entities
{
    public class Inscripcion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de inscripción es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "El formato de fecha no es válido.")]
        public DateTime FechaInscripcion { get; set; }

        [MaxLength(1000, ErrorMessage = "Los detalles de la inscripción no deben exceder los 1000 caracteres.")]
        public string? Detalles { get; set; }

        [Required(ErrorMessage = "El estado de la inscripción es obligatorio.")]
        [EnumDataType(typeof(EstadoInscripcion))]
        public EstadoInscripcion? Estado { get; set; }

        [Required(ErrorMessage = "El ID del Alumno es obligatorio.")]
        public int AlumnoId { get; set; }
    }
}
