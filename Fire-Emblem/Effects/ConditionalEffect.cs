using Fire_Emblem.Conditions;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Bonus;

public class ConditionalEffect : IEffect
{
    public ICondition Condition { get;  }
    public IEffect Effect { get;  }

    public ConditionalEffect(ICondition condition, IEffect effect)
    {
        Condition = condition;
        Effect = effect;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        if (Condition.IsConditionMet(activator, opponent))
            Effect.ApplyEffect(activator, opponent);
    }
}