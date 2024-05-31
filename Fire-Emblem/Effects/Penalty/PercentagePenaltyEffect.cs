using Fire_Emblem.Combats.Stats;
using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects;

public class PercentagePenaltyEffect : IPenaltyEffect
{
    private EffectTarget _target { get; }
    private readonly StatType _statToDecrease;
    private readonly double _percentage;
    private int _penaltyAmount;

    public StatType StatType => _statToDecrease;
    public int? Amount => _penaltyAmount;
    
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
        targetUnit.ApplyStatPenaltyEffect(_statToDecrease, _penaltyAmount);
        targetUnit.AddActiveEffect(this);
    }
}