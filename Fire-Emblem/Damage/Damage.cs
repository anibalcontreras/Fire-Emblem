using Fire_Emblem.Units;
using Fire_Emblem.Views;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Damage;

public abstract class Damage
{
    protected Unit Defender { get; }
    protected Weapon AttackerWeapon { get; }
    private int AttackValue { get; }
    private int ExtraDamage { get; }
    private int FollowUpExtraDamage { get; }

    protected Damage(Unit attacker, Unit defender, int attackValue, int extraDamage, int followUpExtraDamage)
    {
        Defender = defender;
        AttackerWeapon = attacker.Weapon;
        AttackValue = attackValue;
        ExtraDamage = extraDamage;
        FollowUpExtraDamage = followUpExtraDamage;
    }

    public int CalculateDamage(IView view)
    {
        int defenseValue = CalculateDefenseValue();
        double initialDamage = CalculateInitialDamage(defenseValue); 
        int damageAfterExtra = ApplyExtraDamage(initialDamage);
        double totalPercentageReduction = CalculateTotalPercentageReduction();
        double damageAfterPercentageReduction = 
            ApplyPercentageDamageReduction(damageAfterExtra, totalPercentageReduction);
        double finalDamage = ApplyAbsoluteDamageReduction(damageAfterPercentageReduction);
        return UpdateOpponentHpDueTheDamage(finalDamage, view);
    }

    protected abstract int CalculateDefenseValue();
    protected abstract double CalculateTotalPercentageReduction();

    private double CalculateInitialDamage(int defenseValue)
    {
        double attackValue = Convert.ToDouble(AttackValue);
        double weaponTriangleBonus = Convert.ToDouble(AttackerWeapon.GetWtb(Defender.Weapon));
        double initialDamage = (attackValue * weaponTriangleBonus) - defenseValue;
        return Math.Max(0, initialDamage);
    }

    private int ApplyExtraDamage(double initialDamage)
    {
        double truncatedInitialDamage = Math.Truncate(initialDamage);
        double totalDamage = truncatedInitialDamage + ExtraDamage + FollowUpExtraDamage;
        return (int)Math.Max(0, totalDamage);
    }


    private double ApplyPercentageDamageReduction(int damage, double percentageReduction)
    {
        double reductionFactor = 1 - percentageReduction;
        double reducedDamage = damage * reductionFactor;
        return reducedDamage;
    }

    private double ApplyAbsoluteDamageReduction(double damage)
    {
        int absoluteDamageReduction = Defender.AbsoluteDamageReduction;
        return Math.Max(0, damage - absoluteDamageReduction);
    }

    private int UpdateOpponentHpDueTheDamage(double finalDamage, IView view)
    {
        int finalDamageInt = Convert.ToInt32(Math.Floor(finalDamage));
        Defender.CurrentHP -= finalDamageInt;
        return finalDamageInt;
    }
    
}