using Fire_Emblem.Stats;
using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Damage;

public class FollowUpDamage : Damage
{
    public FollowUpDamage(Unit attacker, Unit defender)
        : base(attacker, defender, attacker.GetFollowUpStat(StatType.Atk), attacker.ExtraDamage, 
            0) { }

    protected override int CalculateDefenseValue()
    {
        int defenderFollowUpRes = _defender.GetFollowUpStat(StatType.Res);
        int defenderFollowUpDef = _defender.GetFollowUpStat(StatType.Def);
        return _attackerWeapon is Magic ? defenderFollowUpRes : defenderFollowUpDef;
    }

    protected override double CalculateTotalPercentageReduction()
    {
        return 1 - (1 - _defender.PercentageDamageReduction) * (1 - _defender.FollowUpPercentageDamageReduction);
    }
}