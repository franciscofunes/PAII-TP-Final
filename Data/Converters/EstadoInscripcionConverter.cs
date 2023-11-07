using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Data.Enums;
using System;

namespace Data.Converters
{
    public class EstadoInscripcionConverter : ValueConverter<EstadoInscripcion?, string>
    {
        public EstadoInscripcionConverter()
            : base(
                v => ConvertToString(v),
                v => ConvertToEnum(v)
            )
        {
        }

        private static string ConvertToString(EstadoInscripcion? value)
        {

            return value.ToString();
        }

        private static EstadoInscripcion? ConvertToEnum(string v)
        {
            if (Enum.TryParse(v, out EstadoInscripcion estado))
            {
                return estado;
            }
            return null;
        }
    }
}
