using Fire_Emblem.Combats.Stats;
using Fire_Emblem.Combats.Units;
using Fire_Emblem.Combats.Weapons;

namespace Fire_Emblem.Combats.Damage;

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
        return AttackerWeapon is Magic ? 
            Defender.GetFirstAttackStat(StatType.Res) : Defender.GetFirstAttackStat(StatType.Def);
    }

    protected override double CalculateTotalPercentageReduction()
    {
        return 1 - ((1 - Defender.PercentageDamageReduction) * (1 - Defender.FirstAttackPercentageDamageReduction));
    }
}