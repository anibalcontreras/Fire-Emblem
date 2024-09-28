using Fire_Emblem.Effects;

namespace Fire_Emblem.Skills;

public class Skill
{
    public string Name { get; }
    public MultiEffect Effect { get; }
    public Skill(string name, MultiEffect effect)
    {
        Name = name;
        Effect = effect;
    }
}