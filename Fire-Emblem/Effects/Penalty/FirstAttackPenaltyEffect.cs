using Fire_Emblem.Combats.Stats;
using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects;

public class FirstAttackPenaltyEffect : IEffect
{
    private readonly StatType _statToDecrease;
    private readonly int _percentage;
    private EffectTarget Target { get; }

    private int? _calculatedPenaltyAmount;
    
    public StatType StatType => _statToDecrease;
    public int? Amount => _calculatedPenaltyAmount;

    public FirstAttackPenaltyEffect(StatType statToDecrease, int percentage, EffectTarget target)
    {
        _statToDecrease = statToDecrease;
        _percentage = percentage;
        Target = target;
        _calculatedPenaltyAmount = null;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        int baseStat = targetUnit.GetBaseStat(_statToDecrease);
        _calculatedPenaltyAmount = (int)(baseStat * (_percentage / 100.0));
        targetUnit.ApplyFirstAttackStatPenaltyEffect(_statToDecrease, _calculatedPenaltyAmount.Value);
        targetUnit.AddActiveEffect(this);
    }
}