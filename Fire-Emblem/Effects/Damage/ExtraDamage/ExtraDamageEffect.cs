using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

public class ExtraDamageEffect : IExtraDamageEffect
{
    private readonly int _amount;
    private EffectTarget _target { get; }
    
    public ExtraDamageEffect(int amount, EffectTarget target)
    {
        _amount = amount;
        _target = target;
    }
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyExtraDamageEffect(_amount);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}