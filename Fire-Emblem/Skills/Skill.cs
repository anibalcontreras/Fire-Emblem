using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;

namespace Fire_Emblem.Skills;

public class Skill
{
    public string Name { get; set; }
    public MultiEffect Effect { get; set; }
    public ICondition Condition { get; set; }
    public Skill(string name, ICondition condition, MultiEffect effect)
    {
        Name = name;
        Condition = condition;
        Effect = effect;
    }
}