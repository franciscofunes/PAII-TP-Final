using System.ComponentModel.DataAnnotations;

public class ArgentinaDNIAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int dni)
        {
            if (IsDNIValid(dni))
            {
                return ValidationResult.Success;
            }
        }

        return new ValidationResult("El DNI no es válido");
    }

    private bool IsDNIValid(int dni)
    {
        if ((dni >= 1000000 && dni <= 9999999) || (dni >= 10000000 && dni <= 99999999))
        {
            return true;
        }

        return false;
    }
}
