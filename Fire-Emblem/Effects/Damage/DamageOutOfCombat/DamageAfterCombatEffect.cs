using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.DamageOutOfCombat;

public class DamageAfterCombatEffect : IEffectAfterCombat
{
    private readonly int _amount;
    
    private EffectTarget Target { get; }
    
    public DamageAfterCombatEffect(int amount, EffectTarget target)
    {
        _amount = amount;
        Target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyDamageAfterCombat(_amount);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}