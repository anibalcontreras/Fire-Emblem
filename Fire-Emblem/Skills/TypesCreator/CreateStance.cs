using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Damage.PercentageDamageReduction;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateStance
{
    public static Skill CreateStanceSkill(string skillName, StatType[] stats, int[] statValues, double damageReduction)
    {
        ICondition condition = new RivalBeginAsAttacker();
        List<IEffect> effects = new List<IEffect>();

        for (int i = 0; i < stats.Length; i++)
        {
            IEffect bonusEffect = new BonusEffect(stats[i], statValues[i], EffectTarget.Unit);
            ConditionalEffect conditionalBonusEffect = new ConditionalEffect(condition, bonusEffect);
            effects.Add(conditionalBonusEffect);
        }

        IEffect damageReductionEffect = new FollowUpPercentageDamageReductionEffect(damageReduction, EffectTarget.Unit);
        ConditionalEffect conditionalDamageReductionEffect = new ConditionalEffect(condition, damageReductionEffect);
        effects.Add(conditionalDamageReductionEffect);

        MultiEffect multiEffect = new MultiEffect(effects);

        return new Skill(skillName, multiEffect);
    }
}