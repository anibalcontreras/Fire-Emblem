using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Damage;
using Fire_Emblem.Effects.FollowUp;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateNullFollow
    {
        private static readonly int _penaltyAmount = 4;
        private static readonly double _percentageDamageReduction = 0.5;
        
        public static Skill CreateNullFollowSkill(string skillName, StatType secondaryStat, 
            EffectTarget percentageDamageReductionTarget)
        {
            ICondition trueCondition = CreateTrueCondition();
            IEffect[] effects = CreateEffects(trueCondition, secondaryStat, percentageDamageReductionTarget);
            MultiEffect multiEffect = new MultiEffect(effects);

            return new Skill(skillName, multiEffect);
        }

        private static ICondition CreateTrueCondition()
        {
            return new TrueCondition();
        }

        private static IEffect[] CreateEffects(ICondition trueCondition, StatType secondaryStat, 
            EffectTarget percentageDamageReductionTarget)
        {
            IEffect spdPenaltyEffect = 
                CreateConditionalPenaltyEffect(trueCondition, StatType.Spd, _penaltyAmount);
            IEffect secondaryPenaltyEffect = 
                CreateConditionalPenaltyEffect(trueCondition, secondaryStat, _penaltyAmount);
            IEffect denialFollowUpGuaranteeEffect = 
                CreateConditionalEffect(trueCondition, new DenialFollowUpGuaranteeEffect(EffectTarget.Rival));
            IEffect denialDenialFollowUpEffect = 
                CreateConditionalEffect(trueCondition, new DenialOfDenialFollowUpEffect(EffectTarget.Unit));
            IEffect percentageDamageReductionReductionEffect = 
                CreateConditionalEffect(trueCondition, 
                    new PercentageDamageReductionReductionEffect(_percentageDamageReduction, 
                        percentageDamageReductionTarget));
            return new IEffect[]
            {
                spdPenaltyEffect,
                secondaryPenaltyEffect,
                denialFollowUpGuaranteeEffect,
                denialDenialFollowUpEffect,
                percentageDamageReductionReductionEffect
            };
        }

        private static IEffect CreateConditionalPenaltyEffect(ICondition condition, StatType stat, int value)
        {
            IEffect penaltyEffect = new PenaltyEffect(stat, value, EffectTarget.Rival);
            return new ConditionalEffect(condition, penaltyEffect);
        }

        private static IEffect CreateConditionalEffect(ICondition condition, IEffect effect)
        {
            return new ConditionalEffect(condition, effect);
        }
    }