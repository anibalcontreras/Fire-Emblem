using Fire_Emblem.Condition;
using Fire_Emblem.Effect;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.SkillManagment;

public class Skill
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public MultiEffect Effect { get; set; }
    public MultiCondition Condition { get; set; }
    
    public Skill(string name, string description, MultiCondition condition, MultiEffect effect)
    {
        Name = name;
        Description = description;
        Condition = condition;
        Effect = effect;
    }
    
    public void ActivateEffects(Unit unit, Combat combat, GameView view)
    {
        if (Condition.IsConditionMet(combat))
        {
            Effect.ApplyEffect(unit, view);
        }
    }
    
    public void DeactivateEffects(Unit unit, Combat combat, GameView view)
    {
        if (Condition.IsConditionMet(combat))
        {
            Effect.RevertEffect(unit, view);
        }
    }
    
}