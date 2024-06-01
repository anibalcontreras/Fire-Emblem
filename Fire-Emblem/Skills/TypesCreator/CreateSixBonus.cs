using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public class CreateSixBonus
{
    private const int _defaultBonusValue = 6;

    public static Skill CreateSkill(string skillName, ICondition cond, params StatType[] statTypes)
    {
        MultiEffect bonusEffects = BuildBonusEffects(cond, statTypes);
        return new Skill(skillName, bonusEffects);
    }
    private static MultiEffect BuildBonusEffects(ICondition condition, params StatType[] statTypes)
    {
        ConditionalEffect[] conditionalEffects = statTypes.Select(statType => 
            new ConditionalEffect(condition, 
                EffectBuilder.BuildBonusEffect(statType, _defaultBonusValue, EffectTarget.Unit))
        ).ToArray();
        return new MultiEffect(conditionalEffects);
    }
    
}