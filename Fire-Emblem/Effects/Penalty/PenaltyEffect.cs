using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class PenaltyEffect : IPenaltyEffect
{
    private EffectTarget _target { get; }
    private readonly StatType _statToDecrease;
    private readonly int _amount;
    
    public PenaltyEffect(StatType statToDecrease, int amount, EffectTarget target)
    {
        _statToDecrease = statToDecrease;
        _amount = amount;
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.ApplyStatPenalty(_statToDecrease, _amount);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}