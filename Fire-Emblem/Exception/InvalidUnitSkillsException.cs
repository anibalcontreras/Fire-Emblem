namespace Fire_Emblem.Exception;

public class InvalidUnitSkillsException : ApplicationException
{
    public InvalidUnitSkillsException(string unitName)
        : base($"La unidad {unitName} tiene habilidades no válidas.")
    {
    }
}