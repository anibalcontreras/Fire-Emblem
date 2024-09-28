using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Damage.AbsoluteDamageReduction;

namespace Fire_Emblem.Skills.TypesCreator;

public static class CreateWeaponGuard
{
    public static Skill CreateWeaponGuardSkill(Type weaponType)
    {
        ICondition condition = new RivalWeaponCondition(weaponType);
        IEffect absoluteDamageReductionEffect = new AbsoluteDamageReductionEffect(5, EffectTarget.Unit);
        ConditionalEffect conditionalAbsoluteDamageReductionEffect = new ConditionalEffect(condition, 
            absoluteDamageReductionEffect);
        MultiEffect effects = new MultiEffect(new IEffect[] { conditionalAbsoluteDamageReductionEffect });
        return new Skill(weaponType + " Guard", effects);
    }
}