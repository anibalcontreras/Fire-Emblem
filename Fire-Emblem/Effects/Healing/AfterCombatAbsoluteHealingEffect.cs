using Fire_Emblem.Effects.Damage.DamageOutOfCombat;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Healing;

public class AfterCombatAbsoluteHealingEffect : IEffectAfterCombat
{
    private readonly int _amount;
    private readonly EffectTarget _target;
    
    public AfterCombatAbsoluteHealingEffect(int amount, EffectTarget target)
    {
        _amount = amount;
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyHealingAfterCombat(_amount);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}
