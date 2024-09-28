using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class FirstAttackBonusEffect : IEffect
{
    private readonly StatType _statToIncrease;
    private readonly int _percentage;
    private EffectTarget _target { get; }
    private int? _calculatedBonusAmount;
    private readonly double _totalPercentage = 100.0;

    public FirstAttackBonusEffect(StatType statToIncrease, int percentage, EffectTarget target)
    {
        _statToIncrease = statToIncrease;
        _percentage = percentage;
        _target = target;
        _calculatedBonusAmount = null;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        int baseStat = targetUnit.GetBaseStat(_statToIncrease);
        _calculatedBonusAmount = (int)(baseStat * (_percentage / _totalPercentage));
        targetUnit.ApplyFirstAttackStatBonus(_statToIncrease, _calculatedBonusAmount.Value);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}