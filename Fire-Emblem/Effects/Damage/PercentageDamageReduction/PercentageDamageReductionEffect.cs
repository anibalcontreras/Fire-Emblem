using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects.Damage.PercentageDamageReduction;

public class PercentageDamageReductionEffect : IEffect, IPercentageDamageReductionEffect
{
    private readonly double _percentage;
    private readonly EffectTarget _target;
        
    public PercentageDamageReductionEffect(double percentage, EffectTarget target)
    {
        _percentage = percentage;
        _target = target;
    }
        
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyPercentageDamageReductionEffect(_percentage);
        targetUnit.AddActiveEffect(this);
    }
}