namespace Fire_Emblem.Exception;

public class NonUniqueUnitsException : ApplicationException
{
    public NonUniqueUnitsException()
        : base("El equipo contiene unidades no únicas.")
    {
    }
}