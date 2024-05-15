using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class PercentagePenaltyEffect : IEffect, IPenaltyEffect
{
    public EffectTarget Target { get; }
    private readonly StatType _statToDecrease;
    private readonly double _percentage;
    private int _penaltyAmount;

    public StatType StatType => _statToDecrease;
    public int? Amount => _penaltyAmount;
    
    public PercentagePenaltyEffect(StatType statToDecrease, double percentage, EffectTarget target)
    {
        _statToDecrease = statToDecrease;
        _percentage = percentage;
        Target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        int baseStatValue = targetUnit.GetBaseStat(_statToDecrease);
        _penaltyAmount = (int)(baseStatValue * _percentage);
        targetUnit.ApplyStatPenaltyEffect(_statToDecrease, _penaltyAmount);
        targetUnit.AddActiveEffect(this);
    }
}