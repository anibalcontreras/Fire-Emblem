using Fire_Emblem.Stats;
using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Damage;

// Revisar esto porque está curiso
public class FollowUpDamage : Damage
{
    public FollowUpDamage(Unit attacker, Unit defender)
        : base(attacker, defender, attacker.GetFollowUpStat(StatType.Atk), attacker.ExtraDamage, 
            0)
    {
    }

    protected override int CalculateDefenseValue()
    {
        return AttackerWeapon is Magic ? Defender._followUpRes : Defender._followUpDef;
    }

    protected override double CalculateTotalPercentageReduction()
    {
        return 1 - ((1 - Defender.PercentageDamageReduction) * (1 - Defender.FollowUpPercentageDamageReduction));
    }
}