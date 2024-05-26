using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public class CreateBonus
{
    public static Skill CreateBonusSkill(string name, StatType[] statTypes, int[] values)
    {
        ICondition condition = new TrueCondition();
        List<IEffect> effects = new List<IEffect>();

        for (int i = 0; i < statTypes.Length; i++)
        {
            IEffect bonusEffect = new BonusEffect(statTypes[i], values[i], EffectTarget.Unit);
            ConditionalEffect conditionalBonusEffect = new ConditionalEffect(condition, bonusEffect);
            effects.Add(conditionalBonusEffect);
        }

        MultiEffect multiEffect = new MultiEffect(effects.ToArray());
        return new Skill(name, multiEffect);
    }
}