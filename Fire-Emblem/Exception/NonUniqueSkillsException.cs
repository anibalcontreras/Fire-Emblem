namespace Fire_Emblem.Exception;

public class NonUniqueSkillsException : ApplicationException
{
    public NonUniqueSkillsException(string unitName)
        : base($"La unidad {unitName} tiene habilidades no únicas.")
    {
    }
}