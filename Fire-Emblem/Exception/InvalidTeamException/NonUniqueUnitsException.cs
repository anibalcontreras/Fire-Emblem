namespace Fire_Emblem.Exception;

public class NonUniqueUnitsException : InvalidTeamException
{
    public NonUniqueUnitsException()
        : base("El equipo contiene unidades no únicas.")
    {
    }
}