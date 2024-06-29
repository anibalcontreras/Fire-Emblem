using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class FirstAttackPenaltyEffect : IEffect
{
    private readonly StatType _statToDecrease;
    private readonly int _percentage;
    private EffectTarget Target { get; }
    private int? _calculatedPenaltyAmount;
    public FirstAttackPenaltyEffect(StatType statToDecrease, int percentage, EffectTarget target)
    {
        _statToDecrease = statToDecrease;
        _percentage = percentage;
        Target = target;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        int baseStat = targetUnit.GetBaseStat(_statToDecrease);
        _calculatedPenaltyAmount = (int)(baseStat * (_percentage / 100.0));
        targetUnit.ApplyFirstAttackStatPenalty(_statToDecrease, _calculatedPenaltyAmount.Value);
        EffectsList targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}