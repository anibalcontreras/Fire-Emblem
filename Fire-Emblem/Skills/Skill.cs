using Fire_Emblem.Conditions;
using Fire_Emblem.Effects.Bonus;

namespace Fire_Emblem.Skills;

public class Skill
{
    public string Name { get; set; }
    public MultiEffect Effect { get; set; }
    public Skill(string name, MultiEffect effect)
    {
        Name = name;
        Effect = effect;
    }
}