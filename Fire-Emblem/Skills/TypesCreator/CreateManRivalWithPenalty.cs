using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateManRivalWithPenalty
{
    public static Skill CreateSkill(string skillName, StatType statType, int penaltyValue)
    {
        ICondition condition = new RivalIsManCondition();
        IEffect penaltyEffect = new PenaltyEffect(statType, penaltyValue, EffectTarget.Rival);
        ConditionalEffect conditionalPenaltyEffect = new ConditionalEffect(condition, penaltyEffect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalPenaltyEffect });
        return new Skill(skillName, multiEffect);
    }
}