using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Healing;

public class PercentageHealingEffect : IHealingEffect
{
    private readonly double _percentage;
    
    private EffectTarget Target { get; }
    
    public PercentageHealingEffect(double percentage, EffectTarget target)
    {
        _percentage = percentage;
        Target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyHealing(_percentage);
        targetUnit.AddActiveEffect(this);
    }
}