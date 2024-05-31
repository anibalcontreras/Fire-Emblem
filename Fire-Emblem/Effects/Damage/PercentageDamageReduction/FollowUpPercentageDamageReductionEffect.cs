using Fire_Emblem.Effects.Bonus;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.PercentageDamageReduction;

public class FollowUpPercentageDamageReductionEffect : IEffect
{
    private readonly EffectTarget Target;
    private readonly double _percentage;
    
    public FollowUpPercentageDamageReductionEffect(double percentage, EffectTarget target)
    {
        Target = target;
        _percentage = percentage;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyFollowUpPercentageDamageReduction(_percentage);
        targetUnit.AddActiveEffect(this);
    }
}