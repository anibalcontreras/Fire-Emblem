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
    public SkillTarget Target { get; set; }
    private bool IsActive { get; set; }
    
    public Skill(string name, MultiCondition condition, MultiEffect effect)
    {
        Name = name;
        Condition = condition;
        Effect = effect;
    }
    
    public void ActivateEffects(Combat combat, GameView view, Unit unit, Unit rival)
    {
        switch (Target)
        {
            case SkillTarget.Self:
                if (Condition.IsConditionMet(combat, unit, rival))
                {
                    Effect.ApplyEffect(view, unit, rival);
                    IsActive = true;
                }
                break;
            case SkillTarget.Rival:
                if (Condition.IsConditionMet(combat, rival, unit))
                {
                    Effect.ApplyEffect(view, rival, unit);
                    IsActive = true;
                }
                break;
            case SkillTarget.Allies:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public void DeactivateEffects(Combat combat, GameView view, Unit unit, Unit rival)
    {
        switch (Target)
        {
            case SkillTarget.Self:
                if (IsActive)
                {
                    Effect.RevertEffect(view, unit, rival);
                    IsActive = false;
                }
                break;
            case SkillTarget.Rival:
                if (IsActive)
                {
                    Effect.RevertEffect(view, rival, unit);
                    IsActive = false;
                }
                break;
            case SkillTarget.Allies:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}