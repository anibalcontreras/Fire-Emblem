using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.PercentageDamageReduction;

public class FollowUpPercentageDamageReductionEffect : IEffect
{
    private readonly EffectTarget _target;
    private readonly double _percentage;
    
    public FollowUpPercentageDamageReductionEffect(double percentage, EffectTarget target)
    {
        _target = target;
        _percentage = percentage;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyFollowUpPercentageDamageReduction(_percentage);
        targetUnit.AddActiveEffect(this);
    }
}