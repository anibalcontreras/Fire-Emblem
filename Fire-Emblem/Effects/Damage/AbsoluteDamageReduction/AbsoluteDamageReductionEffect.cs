using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;

public class AbsoluteDamageReductionEffect : IAbsoluteDamageReductionEffect
{
    private readonly int _amount;
    private EffectTarget Target { get; }
    
    public AbsoluteDamageReductionEffect(int amount, EffectTarget target)
    {
        _amount = amount;
        Target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyAbsoluteDamageReduction(_amount);
        targetUnit.AddActiveEffect(this);
    }
}