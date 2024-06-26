namespace Fire_Emblem.Exception;

public class ValueOutOfRangeException : ApplicationException
{
    public ValueOutOfRangeException(int minValue, int maxValue, int actualValue)
        : base($"El valor ingresado ({actualValue}) está fuera del rango permitido ({minValue} - {maxValue}).")
    {
    }
}