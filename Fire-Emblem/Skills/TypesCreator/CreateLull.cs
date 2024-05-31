using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects.Bonus;
using Fire_Emblem.Effects.Bonus.Neutralization;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateLull
{
    public static Skill CreateLullSkill(string name, StatType stat1, StatType stat2)
    {
        ICondition condition = new TrueCondition();

        IEffect stat1PenaltyEffect = new PenaltyEffect(stat1, 3, EffectTarget.Rival);
        IEffect stat1NeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, stat1);
        IEffect stat2PenaltyEffect = new PenaltyEffect(stat2, 3, EffectTarget.Rival);
        IEffect stat2NeutralizationEffect = new NeutralizationBonusEffect(EffectTarget.Rival, stat2);

        ConditionalEffect conditionalStat1PenaltyEffect = new ConditionalEffect(condition, stat1PenaltyEffect);
        ConditionalEffect conditionalStat1NeutralizationEffect = new ConditionalEffect(condition, stat1NeutralizationEffect);
        ConditionalEffect conditionalStat2PenaltyEffect = new ConditionalEffect(condition, stat2PenaltyEffect);
        ConditionalEffect conditionalStat2NeutralizationEffect = new ConditionalEffect(condition, stat2NeutralizationEffect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            conditionalStat1PenaltyEffect,
            conditionalStat1NeutralizationEffect,
            conditionalStat2PenaltyEffect,
            conditionalStat2NeutralizationEffect
        });

        return new Skill(name, multiEffect);
    }
}