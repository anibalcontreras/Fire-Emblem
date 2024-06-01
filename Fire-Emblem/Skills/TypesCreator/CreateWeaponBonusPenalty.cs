using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateWeaponBonusPenalty
{
    public static Skill CreateSkill(string skillName, Type weaponType, StatType bonusStat, int bonusValue, 
        StatType penaltyStat, int penaltyValue)
    {
        ICondition weaponCondition = new UnitWeaponCondition(weaponType);
        IEffect bonusEffect = new BonusEffect(bonusStat, bonusValue, EffectTarget.Unit);
        IEffect penaltyEffect = new PenaltyEffect(penaltyStat, penaltyValue, EffectTarget.Unit);
        ConditionalEffect conditionalBonusEffect = new ConditionalEffect(weaponCondition, bonusEffect);
        ConditionalEffect conditionalPenaltyEffect = new ConditionalEffect(weaponCondition, penaltyEffect);
        MultiEffect multiEffect = new MultiEffect(new IEffect[]
        {
            conditionalBonusEffect, conditionalPenaltyEffect
        });
        return new Skill(skillName, multiEffect);
    }
}