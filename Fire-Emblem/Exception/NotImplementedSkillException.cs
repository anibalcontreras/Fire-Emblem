namespace Fire_Emblem.Exception;

public class NotImplementedSkillException : ApplicationException
{
    private static readonly string _defaultMessage = $"Skill is not implemented.";
    public NotImplementedSkillException() : base(_defaultMessage) { }
}