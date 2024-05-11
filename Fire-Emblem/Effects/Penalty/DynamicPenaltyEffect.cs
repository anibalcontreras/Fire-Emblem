using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class DynamicPenaltyEffect : IEffect, IPenaltyEffect
{
    private readonly StatType _statToDecrease;
    private readonly int _maxAmount;
    public EffectTarget Target { get; private set; }
    public StatType StatType => _statToDecrease;
    private int? _lastCalculatedAmount;
    public int? Amount => _lastCalculatedAmount;

    public DynamicPenaltyEffect(StatType statToDecrease, int maxAmount, EffectTarget target)
    {
        _statToDecrease = statToDecrease;
        _maxAmount = maxAmount;
        Target = target;
        _lastCalculatedAmount = null;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        int lostHp = targetUnit.BaseHp - targetUnit.CurrentHP;
        int penaltyAmount = Math.Min(lostHp, _maxAmount);
        _lastCalculatedAmount = -penaltyAmount;  // Store as a negative value to indicate a penalty

        targetUnit.ApplyStatPenaltyEffect(_statToDecrease, penaltyAmount);
        targetUnit.AddActiveEffect(this);
    }
}