using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class DynamicBonusEffect : IBonusEffect
{
    private readonly StatType _statToIncrease;
    private readonly int _maxAmount;
    private EffectTarget Target { get; }
    public DynamicBonusEffect(StatType statToIncrease, int maxAmount, EffectTarget target)
    {
        _statToIncrease = statToIncrease;
        _maxAmount = maxAmount;
        Target = target;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        int lostHp = targetUnit.BaseHp - targetUnit.CurrentHP;
        int bonusAmount = Math.Min(lostHp, _maxAmount);
        targetUnit.ApplyStatBonus(_statToIncrease, bonusAmount);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}