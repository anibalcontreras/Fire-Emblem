using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

public class FirstAttackExtraDamageEffect : IEffect, IFirstAttackExtraDamageEffect
{
    private readonly int _amount;
    private EffectTarget Target { get; }
    
    public FirstAttackExtraDamageEffect(int amount, EffectTarget target)
    {
        _amount = amount;
        Target = target;
    }
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyFirstAttackExtraDamageEffect(_amount);
        targetUnit.AddActiveEffect(this);
    }
}