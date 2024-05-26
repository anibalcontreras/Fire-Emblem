using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Damage;

public abstract class Damage
{
    protected Unit Attacker { get; }
    protected Unit Defender { get; }
    protected Weapon AttackerWeapon { get; }
    private int AttackValue { get; }
    private int ExtraDamage { get; }
    private int FollowUpExtraDamage { get; }

    protected Damage(Unit attacker, Unit defender, int attackValue, int extraDamage, int followUpExtraDamage)
    {
        Attacker = attacker;
        Defender = defender;
        AttackerWeapon = attacker.Weapon;
        AttackValue = attackValue;
        ExtraDamage = extraDamage;
        FollowUpExtraDamage = followUpExtraDamage;
    }

    public int CalculateDamage()
    {
        int defenseValue = CalculateDefenseValue();
        double initialDamage = CalculateInitialDamage(defenseValue);
        int damageAfterExtra = ApplyExtraDamage(initialDamage);
        double totalPercentageReduction = CalculateTotalPercentageReduction();
        double damageAfterPercentageReduction = ApplyPercentageDamageReduction(damageAfterExtra, totalPercentageReduction);
        double finalDamage = ApplyAbsoluteDamageReduction(damageAfterPercentageReduction);
        return UpdateOpponentHpDueTheDamage(finalDamage);
    }

    protected abstract int CalculateDefenseValue();
    protected abstract double CalculateTotalPercentageReduction();

    private double CalculateInitialDamage(int defenseValue)
    {
        return (Convert.ToDouble(AttackValue) * Convert.ToDouble(AttackerWeapon.GetWtb(Defender.Weapon))) - defenseValue;
    }

    private int ApplyExtraDamage(double initialDamage)
    {
        return (int)Math.Max(0, Math.Truncate(initialDamage) + ExtraDamage + FollowUpExtraDamage);
    }

    private double ApplyPercentageDamageReduction(int damage, double percentageReduction)
    {
        double reductionFactor = 1 - percentageReduction;
        double reducedDamage = damage * reductionFactor;
        return reducedDamage;
    }

    private double ApplyAbsoluteDamageReduction(double damage)
    {
        return Math.Max(0, damage - Defender.AbsoluteDamageReduction);
    }

    private int UpdateOpponentHpDueTheDamage(double finalDamage)
    {
        int finalDamageInt = Convert.ToInt32(Math.Floor(finalDamage));
        Defender.CurrentHP -= finalDamageInt;
        return finalDamageInt;
    }
}