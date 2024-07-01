using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;
public class PerceptiveBonusEffect: IBonusEffect
{
    private readonly int _baseSpdIncrease = 12;
    private readonly int _spdIncrementFactor = 4;
    private EffectTarget _target { get; }

    public PerceptiveBonusEffect(EffectTarget target)
    {
        _target = target;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        int spdBonus = _baseSpdIncrease;
        int baseSpd = targetUnit.GetBaseStat(StatType.Spd);
        int additionalBonus = baseSpd / _spdIncrementFactor;
        spdBonus += additionalBonus;
        targetUnit.ApplyStatBonus(StatType.Spd, spdBonus);
        EffectCollection targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}