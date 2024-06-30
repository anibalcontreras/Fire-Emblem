using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.FollowUp;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateSimpleFlow
{
    private static readonly int _penaltyValue = 4;
    private static readonly int _adjustment = -10;
    public static Skill CreateSimpleFlowSkill(string skillName, StatType dynamicStatType)
    {
        ICondition trueCondition = new TrueCondition();
        IEffect atkPenaltyEffect = CreateConditionalPenaltyEffect(trueCondition, StatType.Atk, _penaltyValue);
        IEffect defPenaltyEffect = CreateConditionalPenaltyEffect(trueCondition, StatType.Def, _penaltyValue);
        ICondition baseStatComparisionWithAdjustment = 
            CreateBaseStatComparisionWithAdjustmentCondition(StatType.Spd, _adjustment);
        IEffect atkDynamicPenaltyEffect = 
            CreateConditionalDynamicPenaltyEffect(baseStatComparisionWithAdjustment, 
                StatType.Atk, dynamicStatType);
        IEffect defDynamicPenaltyEffect = 
            CreateConditionalDynamicPenaltyEffect(baseStatComparisionWithAdjustment, 
                StatType.Def, dynamicStatType);
        ICondition dualStatComparisionCondition = 
            new DualStatComparisonCondition(StatType.Spd, dynamicStatType);
        ICondition andCondition = 
            new AndCondition(baseStatComparisionWithAdjustment, dualStatComparisionCondition);
        IEffect denialFollowUpEffect = 
            CreateConditionalEffect(andCondition, new DenialFollowUpEffect(EffectTarget.Rival));
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            atkPenaltyEffect,
            defPenaltyEffect,
            atkDynamicPenaltyEffect,
            defDynamicPenaltyEffect,
            denialFollowUpEffect
        });
        
        return new Skill(skillName, multiEffect);
    }

    private static IEffect CreateConditionalPenaltyEffect(ICondition condition, StatType stat, int value)
    {
        IEffect penaltyEffect = new PenaltyEffect(stat, value, EffectTarget.Rival);
        return new ConditionalEffect(condition, penaltyEffect);
    }

    private static IEffect CreateConditionalDynamicPenaltyEffect(ICondition condition, 
        StatType stat, StatType dynamicStat)
    {
        IEffect dynamicPenaltyEffect = 
            new DynamicPenaltyEffect(EffectTarget.Rival, stat, dynamicStat);
        return new ConditionalEffect(condition, dynamicPenaltyEffect);
    }

    private static ICondition CreateBaseStatComparisionWithAdjustmentCondition(StatType statType, int adjustment)
    {
        return new BaseStatComparisionWithAdjustmentCondition(statType, adjustment);
    }

    private static IEffect CreateConditionalEffect(ICondition condition, IEffect effect)
    {
        return new ConditionalEffect(condition, effect);
    }
}
