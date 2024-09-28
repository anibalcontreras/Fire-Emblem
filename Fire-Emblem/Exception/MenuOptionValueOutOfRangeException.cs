namespace Fire_Emblem.Exception;

public class MenuOptionValueOutOfRangeException : ApplicationException
{
    public MenuOptionValueOutOfRangeException(int minValue, int maxValue, int actualValue)
        : base($"El valor ingresado ({actualValue}) está fuera del rango permitido ({minValue} - {maxValue}).")
    {
    }
}