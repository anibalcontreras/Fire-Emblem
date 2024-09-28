using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;

public class StatDifferenceDamageReductionEffect : IAbsoluteDamageReductionEffect
{
    private readonly double _percentage = 0.70;
    private readonly int _minReduction = 0;
    private readonly int _maxReduction = 7;
    private readonly StatType _statType;
    private readonly EffectTarget _target;

    public StatDifferenceDamageReductionEffect(StatType statType, EffectTarget target)
    {
        _statType = statType;
        _target = target;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        int activatorStatValue = targetUnit.GetCurrentStat(_statType);
        int opponentStatValue = opponent.GetCurrentStat(_statType);
        int statDifference = activatorStatValue - opponentStatValue;

        int reductionValue = (int)(statDifference * _percentage);
        reductionValue = Math.Clamp(reductionValue, _minReduction, _maxReduction);

        targetUnit.ApplyAbsoluteDamageReduction(reductionValue);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}