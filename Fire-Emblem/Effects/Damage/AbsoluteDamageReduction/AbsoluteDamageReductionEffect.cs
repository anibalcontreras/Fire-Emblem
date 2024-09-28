using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;

public class AbsoluteDamageReductionEffect : IAbsoluteDamageReductionEffect
{
    private readonly int _amount;
    private EffectTarget _target { get; }
    
    public AbsoluteDamageReductionEffect(int amount, EffectTarget target)
    {
        _amount = amount;
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyAbsoluteDamageReduction(_amount);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}