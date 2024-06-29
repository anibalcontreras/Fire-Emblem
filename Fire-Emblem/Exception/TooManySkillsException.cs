namespace Fire_Emblem.Exception;

public class TooManySkillsException : ApplicationException
{
    public TooManySkillsException(string unitName, int maxSkills, int actualSkills)
        : base($"La unidad {unitName} tiene demasiadas " +
               $"habilidades (máximo: {maxSkills}, actual: {actualSkills}).")
    {
    }
}