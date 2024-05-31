using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator
{
    public static class CreateBrazen
    {
        public static Skill CreateBrazenSkill(string skillName, StatType statType1, StatType statType2)
        {
            ICondition condition = new UnitHpThresholdCondition(0.8);

            IEffect bonusEffect1 = new BonusEffect(statType1, 10, EffectTarget.Unit);
            IEffect bonusEffect2 = new BonusEffect(statType2, 10, EffectTarget.Unit);

            ConditionalEffect conditionalBonusEffect1 = new ConditionalEffect(condition, bonusEffect1);
            ConditionalEffect conditionalBonusEffect2 = new ConditionalEffect(condition, bonusEffect2);

            MultiEffect multiEffect = new MultiEffect(new IEffect[] { conditionalBonusEffect1, conditionalBonusEffect2 });

            return new Skill(skillName, multiEffect);
        }
    }
}