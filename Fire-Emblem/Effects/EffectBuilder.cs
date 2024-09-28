using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Effects;

public static class EffectBuilder
{
    public static IEffect BuildBonusEffect(StatType statType, int bonus, EffectTarget target)
    {
        return new BonusEffect(statType, bonus, target);
    }
    public static IEffect BuildNeutralizationBonusEffect(StatType statType, EffectTarget target)
    {
        return new NeutralizationBonusEffect(target, statType);
    }
    public static IEffect BuildPenaltyEffect(StatType statType, int penalty, EffectTarget target)
    {
        return new PenaltyEffect(statType, penalty, target);
    }
    public static IEffect BuildNeutralizationPenaltyEffect(StatType statType, EffectTarget target)
    {
        return new NeutralizationPenaltyEffect(target, statType);
    }
}