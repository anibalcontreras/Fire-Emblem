using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Damage.PercentageDamageReduction;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateStance
{
    private static readonly double _damageReduction = 0.1;
    public static Skill CreateStanceSkill(string skillName, StatType[] stats, int[] statValues)
    {
        ICondition condition = CreateCondition();
        IEffect[] effects = CreateEffects(condition, stats, statValues);
        MultiEffect multiEffect = new MultiEffect(effects);

        return new Skill(skillName, multiEffect);
    }

    private static ICondition CreateCondition()
    {
        return new RivalBeginAsAttacker();
    }

    private static IEffect[] CreateEffects(ICondition condition, StatType[] stats, int[] statValues)
    {
        List<IEffect> effects = CreateBonusEffects(condition, stats, statValues);
        IEffect damageReductionEffect = CreateDamageReductionEffect(condition);
        effects.Add(damageReductionEffect);

        return effects.ToArray();
    }

    private static List<IEffect> CreateBonusEffects(ICondition condition, StatType[] stats, int[] statValues)
    {
        List<IEffect> effects = new List<IEffect>();
        for (int i = 0; i < stats.Length; i++)
        {
            IEffect bonusEffect = new BonusEffect(stats[i], statValues[i], EffectTarget.Unit);
            ConditionalEffect conditionalBonusEffect = new ConditionalEffect(condition, bonusEffect);
            effects.Add(conditionalBonusEffect);
        }
        return effects;
    }

    private static IEffect CreateDamageReductionEffect(ICondition condition)
    {
        
        IEffect reductionEffect = new FollowUpPercentageDamageReductionEffect(_damageReduction, EffectTarget.Unit);
        return new ConditionalEffect(condition, reductionEffect);
    }
}
