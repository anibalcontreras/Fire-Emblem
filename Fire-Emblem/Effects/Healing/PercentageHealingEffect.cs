using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Healing;

public class PercentageHealingEffect : IHealingEffect
{
    private readonly double _percentage;

    private readonly EffectTarget _target;
    
    public PercentageHealingEffect(double percentage, EffectTarget target)
    {
        _percentage = percentage;
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyPercentageHealing(_percentage);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}