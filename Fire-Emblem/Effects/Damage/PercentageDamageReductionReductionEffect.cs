using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage;

public class PercentageDamageReductionReductionEffect : IEffect
{
    private readonly double _percentage;
    private readonly EffectTarget _target;
    
    public PercentageDamageReductionReductionEffect(double percentage, EffectTarget target)
    {
        _percentage = percentage;
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.SetPercentageDamageReductionReduction(_percentage);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}