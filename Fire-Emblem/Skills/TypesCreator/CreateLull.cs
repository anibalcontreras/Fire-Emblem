using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateLull
{
    
    private static readonly int _penaltyValue = 3;
    public static Skill CreateLullSkill(string name, StatType firstStat, StatType secondStat)
    {
        ICondition condition = CreateCondition();
        IEffect[] effects = CreateEffects(condition, firstStat, secondStat);
        MultiEffect multiEffect = new MultiEffect(effects);
        return new Skill(name, multiEffect);
    }

    private static ICondition CreateCondition()
    {
        return new TrueCondition();
    }

    private static IEffect[] CreateEffects(ICondition condition, StatType firstStat, StatType secondStat)
    {
        IEffect[] firstStatEffects = CreateConditionalEffects(condition, firstStat);
        IEffect[] secondStatEffects = CreateConditionalEffects(condition, secondStat);
        return firstStatEffects.Concat(secondStatEffects).ToArray();
    }

    private static IEffect[] CreateConditionalEffects(ICondition condition, StatType stat)
    {
        IEffect penaltyEffect = new PenaltyEffect(stat, _penaltyValue, EffectTarget.Rival);
        IEffect neutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, stat);
        ConditionalEffect conditionalPenaltyEffect = new ConditionalEffect(condition, penaltyEffect);
        ConditionalEffect conditionalNeutralizationEffect = new ConditionalEffect(condition, neutralizationEffect);
        return new IEffect[] { conditionalPenaltyEffect, conditionalNeutralizationEffect };
    }
}