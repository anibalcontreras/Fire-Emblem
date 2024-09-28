namespace Fire_Emblem.Exception;

public class InvalidUnitCountException : InvalidTeamException
{
    public InvalidUnitCountException(int minUnits, int maxUnits, int actualUnits)
        : base($"El equipo debe tener entre {minUnits} y {maxUnits} unidades, pero tiene {actualUnits}.")
    {
    }
}