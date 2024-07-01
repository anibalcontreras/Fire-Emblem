using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

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
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}