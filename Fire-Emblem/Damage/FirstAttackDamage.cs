using Fire_Emblem.Stats;
using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Damage;

public class FirstAttackDamage : Damage
{
    public FirstAttackDamage(Unit attacker, Unit defender)
        : base(attacker, defender, attacker.GetFirstAttackStat(StatType.Atk), 
            attacker.ExtraDamage + attacker.FirstAttackExtraDamage
            , 0)
    {
    }

    protected override int CalculateDefenseValue()
    {
        return _attackerWeapon is Magic ? 
            _defender.GetFirstAttackStat(StatType.Res) : _defender.GetFirstAttackStat(StatType.Def);
    }

    protected override double CalculateTotalPercentageReduction()
    {
        return 1 - ((1 - _defender.PercentageDamageReduction) * (1 - _defender.FirstAttackPercentageDamageReduction));
    }
}