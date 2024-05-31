using Fire_Emblem.Combats.Conditions;
using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects;

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