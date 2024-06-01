using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.PercentageDamageReduction;

public class PercentageDamageReductionEffect : IPercentageDamageReductionEffect
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
        targetUnit.ApplyPercentageDamageReduction(_percentage);
        targetUnit.AddActiveEffect(this);
    }
}