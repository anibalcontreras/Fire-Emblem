using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Damage.PercentageDamageReduction;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateRemote
{

    private static readonly int _bonusValue = 7;
    private static readonly double _percentageReduction = 0.3;
    public static Skill CreateRemoteSkill(string skillName, StatType secondaryStat, int secondaryStatValue)
    {
        ICondition condition = CreateCondition();
        IEffect[] effects = CreateEffects(condition, secondaryStat, secondaryStatValue);
        MultiEffect multiEffect = new MultiEffect(effects);

        return new Skill(skillName, multiEffect);
    }

    private static ICondition CreateCondition()
    {
        return new UnitBeginAsAttackerCondition();
    }

    private static IEffect[] CreateEffects(ICondition condition, StatType secondaryStat, int secondaryStatValue)
    {
        IEffect atkBonusEffect = CreateBonusEffect(condition, StatType.Atk, _bonusValue);
        IEffect secondaryBonusEffect = CreateBonusEffect(condition, secondaryStat, secondaryStatValue);
        IEffect firstAttackPercentageDamageReductionEffect = 
            CreateFirstAttackPercentageDamageReductionEffect(condition);

        return new IEffect[] { atkBonusEffect, secondaryBonusEffect, firstAttackPercentageDamageReductionEffect };
    }

    private static IEffect CreateBonusEffect(ICondition condition, StatType stat, int value)
    {
        IEffect bonusEffect = new BonusEffect(stat, value, EffectTarget.Unit);
        return new ConditionalEffect(condition, bonusEffect);
    }

    private static IEffect CreateFirstAttackPercentageDamageReductionEffect(ICondition condition)
    {
        IEffect reductionEffect = 
            new FirstAttackPercentageDamageReductionEffect(_percentageReduction, EffectTarget.Unit);
        return new ConditionalEffect(condition, reductionEffect);
    }
}