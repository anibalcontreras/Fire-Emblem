using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.CounterattackDenial;

public class CounterattackDenialEffect : IEffect
{
    private EffectTarget _target { get; }
    
    public CounterattackDenialEffect(EffectTarget target)
    {
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.SetNullifyCounterattack();
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}
