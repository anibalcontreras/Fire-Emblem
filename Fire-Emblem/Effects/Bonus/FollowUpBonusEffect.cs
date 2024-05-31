using Fire_Emblem.Combats.Stats;
using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects;

public class FollowUpBonusEffect : IEffect
{
    private readonly StatType _statToIncrease;
    private readonly int _percentage;
    private EffectTarget Target { get; }

    private int? _calculatedBonusAmount;
    
    public StatType StatType => _statToIncrease;
    public int? Amount => _calculatedBonusAmount;

    public FollowUpBonusEffect(StatType statToIncrease, int percentage, EffectTarget target)
    {
        _statToIncrease = statToIncrease;
        _percentage = percentage;
        Target = target;
        _calculatedBonusAmount = null;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        int baseStat = targetUnit.GetBaseStat(_statToIncrease);
        _calculatedBonusAmount = (int)(baseStat * (_percentage / 100.0));
        targetUnit.ApplyFirstAttackStatBonusEffect(_statToIncrease, _calculatedBonusAmount.Value);
        targetUnit.AddActiveEffect(this);
    }
}