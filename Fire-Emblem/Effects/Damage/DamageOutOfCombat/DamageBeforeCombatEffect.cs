using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.DamageOutOfCombat;

public class DamageBeforeCombatEffect : IDamageBeforeCombatEffect
{
    private readonly int _amount;
    
    private EffectTarget Target { get; }
    
    public DamageBeforeCombatEffect(int amount, EffectTarget target)
    {
        _amount = amount;
        Target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyDamageBeforeCombat(_amount);
        targetUnit.AddActiveEffect(this);
    }
}