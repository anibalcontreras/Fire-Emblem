using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Damage;

public class FirstAttackDamage : Damage
{
    public FirstAttackDamage(Unit attacker, Unit defender)
        : base(attacker, defender, attacker.FirstAttackAtk, attacker.ExtraDamage + attacker.FirstAttackExtraDamage
            , 0)
    {
    }

    protected override int CalculateDefenseValue()
    {
        return AttackerWeapon is Magic ? Defender.FirstAttackRes : Defender.FirstAttackDef;
    }

    protected override double CalculateTotalPercentageReduction()
    {
        return 1 - ((1 - Defender.PercentageDamageReduction) * (1 - Defender.FirstAttackPercentageDamageReduction));
    }
}