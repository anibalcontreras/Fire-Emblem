namespace Fire_Emblem.Exception;

public class NonUniqueSkillsException : InvalidTeamException
{
    public NonUniqueSkillsException(string unitName)
        : base($"La unidad {unitName} tiene habilidades no únicas.")
    {
    }
}