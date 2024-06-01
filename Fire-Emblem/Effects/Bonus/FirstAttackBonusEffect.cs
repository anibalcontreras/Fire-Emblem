using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class FirstAttackBonusEffect : IEffect
{
    private readonly StatType _statToIncrease;
    private readonly int _percentage;
    private EffectTarget Target { get; }
    private int? _calculatedBonusAmount;

    public FirstAttackBonusEffect(StatType statToIncrease, int percentage, EffectTarget target)
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
        targetUnit.ApplyFirstAttackStatBonus(_statToIncrease, _calculatedBonusAmount.Value);
        targetUnit.AddActiveEffect(this);
    }
}