using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Units;

namespace Fire_Emblem.Skills;

public class Skill
{
    public string Name { get; set; }
    public MultiEffect Effect { get; set; }
    public MultiCondition Condition { get; set; }
    public Skill(string name, MultiCondition condition, MultiEffect effect)
    {
        Name = name;
        Condition = condition;
        Effect = effect;
    }
    
    public void ActivateEffects(GameView view, Unit unit, Unit rival)
    {
        foreach (IEffect effect in Effect)
        {
            effect.ApplyEffect(unit, rival);
        }
    }
}