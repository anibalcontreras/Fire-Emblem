using Fire_Emblem.Combats.Conditions;
using Fire_Emblem.Combats.Effects;
using Fire_Emblem.Combats.Effects.Damage.AbsoluteDamageReduction;

namespace Fire_Emblem.Combats.Skills.TypesCreator;

public static class CreateWeaponGuard
{
    public static Skill CreateWeaponGuardSkill(string weaponType)
    {
        ICondition condition = new RivalWeaponCondition(weaponType);
        IEffect absoluteDamageReductionEffect = new AbsoluteDamageReductionEffect(5, EffectTarget.Unit);
        ConditionalEffect conditionalAbsoluteDamageReductionEffect = new ConditionalEffect(condition, 
            absoluteDamageReductionEffect);

        MultiEffect effects = new MultiEffect(new IEffect[] { conditionalAbsoluteDamageReductionEffect });

        return new Skill(weaponType + " Guard", effects);
    }
}