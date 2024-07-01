using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class DynamicPenaltyEffect : IPenaltyEffect
{
    private EffectTarget _target { get; }
    private StatType _statType { get; }
    private StatType _statTypeCondition { get; }
    private double _percentage = 0.8;
    private int _maxPenalty = 8;
    
    public DynamicPenaltyEffect(EffectTarget target, StatType statType, StatType statTypeCondition)
    {
        _target = target;
        _statType = statType;
        _statTypeCondition = statTypeCondition;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        int activatorBaseRes = activator.GetBaseStat(_statTypeCondition);
        int opponentBaseRes = opponent.GetBaseStat(_statTypeCondition);
        int resDifference = activatorBaseRes - opponentBaseRes;
        int penaltyAmount = (int)(_percentage * resDifference);
        if (resDifference < 0)
            penaltyAmount = 0;
        else
            penaltyAmount = Math.Min(Math.Max(penaltyAmount, 0), 8);
        targetUnit.ApplyStatPenalty(_statType, penaltyAmount);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}