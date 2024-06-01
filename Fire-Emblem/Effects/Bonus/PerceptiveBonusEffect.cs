using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;
public class PerceptiveBonusEffect: IBonusEffect
{
    private readonly int _baseSpdIncrease = 12;
    private readonly int _spdIncrementFactor = 4;
    private EffectTarget Target { get; }

    public PerceptiveBonusEffect(EffectTarget target)
    {
        Target = target;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        int spdBonus = _baseSpdIncrease;
        int baseSpd = targetUnit.GetBaseStat(StatType.Spd);
        int additionalBonus = baseSpd / _spdIncrementFactor;
        spdBonus += additionalBonus;
        targetUnit.ApplyStatBonus(StatType.Spd, spdBonus);
        targetUnit.AddActiveEffect(this);
    }
}