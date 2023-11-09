using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Data.Enums;

namespace Data.Converters
{
    public class EstadoInscripcionConverter : ValueConverter<EstadoInscripcion?, string>
    {
        public EstadoInscripcionConverter()
            : base(
                value => ConvertToString(value),
                value => ConvertToEnum(value)
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
