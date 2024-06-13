using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Healing;

public class AbsoluteHealingEffect : IHealingEffect
{
    private readonly int _amount;
    private EffectTarget Target { get; }
    
    public AbsoluteHealingEffect(int amount, EffectTarget target)
    {
        _amount = amount;
        Target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyHealing(_amount);
        targetUnit.AddActiveEffect(this);
    }
}
