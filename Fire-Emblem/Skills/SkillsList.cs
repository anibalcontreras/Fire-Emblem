namespace Fire_Emblem.Skills;

public class SkillsList
{
    private readonly List<Skill> _skills = new();

    public IEnumerable<Skill> Items => _skills.AsReadOnly();
    
    public void AddSkill(Skill skill)
        => _skills.Add(skill);
    
    public int Count()
        => _skills.Count;
    
}