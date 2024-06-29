using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.CounterattackDenial;

public class CounterattackDenialEffect : IEffect
{
    private EffectTarget Target { get; }
    
    public CounterattackDenialEffect(EffectTarget target)
    {
        Target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        targetUnit.SetNullifyCounterattack();
        EffectsList targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}
