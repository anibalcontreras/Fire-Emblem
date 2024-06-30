using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Damage.DamageOutOfCombat;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreatePush
    {
        private static readonly int _statBonus = 7;
        private static readonly int _damageAfterCombat = 5;
        private static readonly double _hpThreshold = 0.25;

        
        public static Skill CreatePushSkill(string skillName, StatType statType1, StatType statType2)
        {
            ICondition hpThresholdCondition = CreateHpThresholdCondition();
            IEffect[] effects = CreateEffects(hpThresholdCondition, statType1, statType2);
            MultiEffect multiEffect = new MultiEffect(effects);

            return new Skill(skillName, multiEffect);
        }

        private static ICondition CreateHpThresholdCondition()
        {
            return new UnitHpStartOfCombatGreaterThanCondition(_hpThreshold);
        }

        private static IEffect[] CreateEffects(ICondition hpThresholdCondition, StatType statType1, StatType statType2)
        {
            List<IEffect> effects = new List<IEffect>();
            effects.Add(CreateConditionalBonusEffect(hpThresholdCondition, statType1, _statBonus));
            effects.Add(CreateConditionalBonusEffect(hpThresholdCondition, statType2, _statBonus));
            effects.Add(CreateConditionalDamageOutOfCombatEffect(hpThresholdCondition));

            return effects.ToArray();
        }

        private static IEffect CreateConditionalBonusEffect(ICondition condition, StatType stat, int value)
        {
            IEffect bonusEffect = new BonusEffect(stat, value, EffectTarget.Unit);
            return new ConditionalEffect(condition, bonusEffect);
        }

        private static IEffect CreateConditionalDamageOutOfCombatEffect(ICondition hpThresholdCondition)
        {
            ICondition unitIsAliveCondition = new IsUnitAliveCondition();
            ICondition unitHasAttackedCondition = new HasUnitAttackedCondition();
            ICondition unitAndCondition = new AndCondition(unitIsAliveCondition, 
                unitHasAttackedCondition, hpThresholdCondition);

            IEffect damageOutOfCombatEffect = new DamageAfterCombatEffect(_damageAfterCombat, 
                EffectTarget.Unit);
            return new ConditionalEffect(unitAndCondition, damageOutOfCombatEffect);
        }
    }