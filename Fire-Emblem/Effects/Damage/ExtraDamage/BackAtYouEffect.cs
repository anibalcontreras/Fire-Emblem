using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

public class BackAtYouEffect : IExtraDamageEffect
{
    private EffectTarget _target { get; }
    private readonly int _halfDamage = 2;
        
    public BackAtYouEffect(EffectTarget target)
    {
        _target = target;
    }
        
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        int extraDamage = (activator.BaseHp - activator.CurrentHP) / _halfDamage;
        targetUnit.ApplyExtraDamageEffect(extraDamage);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}