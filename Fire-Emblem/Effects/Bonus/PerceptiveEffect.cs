using Fire_Emblem.Combats.Stats;
using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects;
public class PerceptiveEffect: IBonusEffect
{
    private readonly int _baseSpdIncrease = 12;
    private readonly int _spdIncrementFactor = 4;

    public StatType StatType => StatType.Spd;
    public int? Amount { get; private set; }
    private EffectTarget Target { get; }

    public PerceptiveEffect(EffectTarget target)
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
        targetUnit.ApplyStatBonusEffect(StatType.Spd, spdBonus);
        targetUnit.AddActiveEffect(this);
        Amount = spdBonus;
    }
}