using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects.Damage.ExtraDamage;

public class ExtraDamageEffect : IExtraDamageEffect
{
    private readonly int _amount;
    private EffectTarget Target { get; }
    
    public ExtraDamageEffect(int amount, EffectTarget target)
    {
        _amount = amount;
        Target = target;
    }
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyExtraDamageEffect(_amount);
        targetUnit.AddActiveEffect(this);
    }
}