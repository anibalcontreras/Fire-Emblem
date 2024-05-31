using Fire_Emblem.Combats.Conditions;
using Fire_Emblem.Combats.Effects;
using Fire_Emblem.Combats.Stats;

namespace Fire_Emblem.Combats.Skills.TypesCreator;

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