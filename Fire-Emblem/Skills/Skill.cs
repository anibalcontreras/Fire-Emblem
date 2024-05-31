using Fire_Emblem.Combats.Effects;
using Fire_Emblem.Combats.Conditions;

namespace Fire_Emblem.Combats.Skills;

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