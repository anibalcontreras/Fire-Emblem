using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.CounterattackDenial;

public class CounterattackDenialDenialEffect : IEffect
{
    private EffectTarget Target { get; }
    
    public CounterattackDenialDenialEffect(EffectTarget target)
    {
        Target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.SetNullifyNullifiedCounterattack();
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}
