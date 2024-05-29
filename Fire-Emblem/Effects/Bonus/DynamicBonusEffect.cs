using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class DynamicBonusEffect : IBonusEffect
{
    private readonly StatType _statToIncrease;
    private readonly int _maxAmount;
    private EffectTarget Target { get; }
    public StatType StatType => _statToIncrease;
    private int? _lastCalculatedAmount;
    public int? Amount => _lastCalculatedAmount;

    public DynamicBonusEffect(StatType statToIncrease, int maxAmount, EffectTarget target)
    {
        _statToIncrease = statToIncrease;
        _maxAmount = maxAmount;
        Target = target;
        _lastCalculatedAmount = null;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        int lostHp = targetUnit.BaseHp - targetUnit.CurrentHP;
        int bonusAmount = Math.Min(lostHp, _maxAmount);
        _lastCalculatedAmount = bonusAmount;

        targetUnit.ApplyStatBonusEffect(_statToIncrease, bonusAmount);
        targetUnit.AddActiveEffect(this);
    }
}