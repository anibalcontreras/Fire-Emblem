using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects.Damage.PercentageDamageReduction;

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
        targetUnit.ApplyFollowUpPercentageDamageReductionEffect(_percentage);
        targetUnit.AddActiveEffect(this);
    }
}