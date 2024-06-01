using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class PercentagePenaltyEffect : IPenaltyEffect
{
    private EffectTarget _target { get; }
    private readonly StatType _statToDecrease;
    private readonly double _percentage;
    private int _penaltyAmount;
    
    public PercentagePenaltyEffect(StatType statToDecrease, double percentage, EffectTarget target)
    {
        _statToDecrease = statToDecrease;
        _percentage = percentage;
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        int baseStatValue = targetUnit.GetBaseStat(_statToDecrease);
        _penaltyAmount = (int)(baseStatValue * _percentage);
        targetUnit.ApplyStatPenalty(_statToDecrease, _penaltyAmount);
        targetUnit.AddActiveEffect(this);
    }
}