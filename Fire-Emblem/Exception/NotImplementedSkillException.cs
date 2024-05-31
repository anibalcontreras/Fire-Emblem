namespace Fire_Emblem.Combats.Exception;

public class NotImplementedSkillException : ApplicationException
{
    private static readonly string DefaultMessage = $"Skill is not implemented.";
    public NotImplementedSkillException() : base(DefaultMessage) { }
}