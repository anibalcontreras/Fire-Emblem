using Fire_Emblem.Effects.Damage.DamageOutOfCombat;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Healing;

public class AfterCombatAbsoluteHealingEffect : IEffectAfterCombat
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
        targetUnit.ApplyHealingAfterCombat(_amount);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}
