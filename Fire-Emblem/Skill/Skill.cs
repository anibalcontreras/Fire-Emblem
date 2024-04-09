namespace Fire_Emblem.SkillManagment;

public class Skill
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public Skill(string name, string description)
    {
        Name = name;
        Description = description;
    }
}