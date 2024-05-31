using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateBoost
{
    public static Skill CreateBoostSkill(string name, StatType statToBoost, int boostAmount)
    {
        ICondition hpAboveRivalPlusThree = new HpComparisonCondition(3);

        IEffect bonusEffect = new BonusEffect(statToBoost, boostAmount, EffectTarget.Unit);
        ConditionalEffect conditionalBonusEffect = new ConditionalEffect(hpAboveRivalPlusThree, bonusEffect);

        MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalBonusEffect });

        return new Skill(name, multiEffect);
    }

}