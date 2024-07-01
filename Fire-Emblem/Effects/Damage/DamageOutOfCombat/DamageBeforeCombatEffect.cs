using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.DamageOutOfCombat;

public class DamageBeforeCombatEffect : IDamageBeforeCombatEffect
{
    private readonly int _amount;
    
    private EffectTarget _target { get; }
    
    public DamageBeforeCombatEffect(int amount, EffectTarget target)
    {
        _amount = amount;
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyDamageBeforeCombat(_amount);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}