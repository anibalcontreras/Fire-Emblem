using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Stats;
namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateBlow
{
    public static Skill CreateBlowSkill(string skillName, StatType stat, int statValue)
    {
        ICondition condition = new UnitBeginAsAttackerCondition();
        IEffect bonusEffect = new BonusEffect(stat, statValue, EffectTarget.Unit);
        ConditionalEffect conditionalBonusEffect = new ConditionalEffect(condition, bonusEffect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalBonusEffect });
        return new Skill(skillName, multiEffect);
    }
}