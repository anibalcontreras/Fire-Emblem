using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Damage.PercentageDamageReduction;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateRemote
{
    public static Skill CreateRemoteSkill(string skillName, StatType secondaryStat, int secondaryStatValue)
    {
        ICondition condition = new UnitBeginAsAttackerCondition();
        IEffect atkBonusEffect = new BonusEffect(StatType.Atk, 7, EffectTarget.Unit);
        IEffect secondaryBonusEffect = new BonusEffect(secondaryStat, secondaryStatValue, EffectTarget.Unit);
        IEffect firstAttackPercentageDamageReductionEffect = 
            new FirstAttackPercentageDamageReductionEffect(0.3, EffectTarget.Unit);
        ConditionalEffect conditionalAtkBonusEffect = new ConditionalEffect(condition, atkBonusEffect);
        ConditionalEffect conditionalSecondaryBonusEffect = new ConditionalEffect(condition, secondaryBonusEffect);
        ConditionalEffect conditionalFirstAttackPercentageDamageReductionEffect = 
            new ConditionalEffect(condition, firstAttackPercentageDamageReductionEffect);
        MultiEffect effects = new MultiEffect(new IEffect[]
        {
            conditionalAtkBonusEffect,
            conditionalSecondaryBonusEffect,
            conditionalFirstAttackPercentageDamageReductionEffect
        });
        return new Skill(skillName, effects);
    }
}