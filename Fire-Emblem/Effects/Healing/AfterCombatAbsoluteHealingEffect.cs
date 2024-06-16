using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Healing;

public class AfterCombatAbsoluteHealingEffect : IEffect
{
    private readonly int _amount;
    private EffectTarget Target { get; }
    
    public AfterCombatAbsoluteHealingEffect(int amount, EffectTarget target)
    {
        _amount = amount;
        Target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyHealingOutOfCombat(_amount);
        targetUnit.AddActiveEffect(this);
    }
}
