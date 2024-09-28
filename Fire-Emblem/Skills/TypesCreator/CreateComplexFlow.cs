using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;
using Fire_Emblem.Effects.Damage.ExtraDamage;
using Fire_Emblem.Effects.FollowUp;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateComplexFlow
    {
        public static Skill CreateComplexFlowSkill(string skillName, StatType statType)
        {
            ICondition unitBeginAsAttacker = CreateUnitBeginAsAttackerCondition();
            ICondition statComparisionWithAdjustment = 
                CreateStatComparisionWithAdjustmentCondition(StatType.Spd, -10);
            ICondition andCondition = CreateAndCondition(unitBeginAsAttacker, statComparisionWithAdjustment);
            IEffect[] effects = CreateEffects(unitBeginAsAttacker, andCondition, statType);

            MultiEffect multiEffect = new MultiEffect(effects);
            return new Skill(skillName, multiEffect);
        }

        private static ICondition CreateUnitBeginAsAttackerCondition()
        {
            return new UnitBeginAsAttackerCondition();
        }

        private static ICondition CreateStatComparisionWithAdjustmentCondition(StatType statType, int adjustment)
        {
            return new StatComparisionWithAdjustmentCondition(statType, adjustment);
        }

        private static ICondition CreateAndCondition(ICondition condition1, ICondition condition2)
        {
            return new AndCondition(condition1, condition2);
        }

        private static IEffect[] CreateEffects(ICondition unitBeginAsAttacker, 
            ICondition andCondition, StatType statType)
        {
            IEffect denialOfDenialFollowUpEffect = 
                CreateConditionalEffect(unitBeginAsAttacker, 
                    new DenialOfDenialFollowUpEffect(EffectTarget.Unit));
            IEffect extraDamagePerStatDifference = 
                CreateConditionalEffect(andCondition,
                    new ExtraDamagePerStatDifferenceEffect(statType, EffectTarget.Unit));
            IEffect statDifferenceDamageReductionEffect = 
                CreateConditionalEffect(andCondition, 
                new StatDifferenceDamageReductionEffect(statType, EffectTarget.Unit));
            return new IEffect[]
            {
                denialOfDenialFollowUpEffect,
                extraDamagePerStatDifference,
                statDifferenceDamageReductionEffect
            };
        }

        private static IEffect CreateConditionalEffect(ICondition condition, IEffect effect)
        {
            return new ConditionalEffect(condition, effect);
        }
    }