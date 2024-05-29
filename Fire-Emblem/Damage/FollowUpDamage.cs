using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Damage;

public class FollowUpDamage : Damage
{
    public FollowUpDamage(Unit attacker, Unit defender)
        : base(attacker, defender, attacker.FollowUpAtk, attacker.ExtraDamage, 
            attacker.FirstAttackExtraDamage)
    {
    }

    protected override int CalculateDefenseValue()
    {
        return AttackerWeapon is Magic ? Defender.FollowUpRes : Defender.FollowUpDef;
    }

    protected override double CalculateTotalPercentageReduction()
    {
        return 1 - ((1 - Defender.PercentageDamageReduction) * (1 - Defender.FollowUpPercentageDamageReduction));
    }
}