using Fire_Emblem.Units;
using Fire_Emblem.Views;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Damage;

public abstract class Damage
{
    private Unit _attacker { get; }
    protected Unit _defender { get; }
    protected Weapon _attackerWeapon { get; }
    private int _attackValue { get; }
    private int _extraDamage { get; }
    private int _followUpExtraDamage { get; }

    protected Damage(Unit attacker, Unit defender, int attackValue, int extraDamage, int followUpExtraDamage)
    {
        _attacker = attacker;
        _defender = defender;
        _attackerWeapon = attacker.Weapon;
        _attackValue = attackValue;
        _extraDamage = extraDamage;
        _followUpExtraDamage = followUpExtraDamage;
    }

    public int CalculateDamage()
    {
        int defenseValue = CalculateDefenseValue();
        double initialDamage = CalculateInitialDamage(defenseValue); 
        int damageAfterExtra = ApplyExtraDamage(initialDamage);
        double totalPercentageReduction = CalculateTotalPercentageReduction();
        double damageAfterPercentageReduction = 
            ApplyPercentageDamageReduction(damageAfterExtra, totalPercentageReduction);
        double finalDamage = ApplyAbsoluteDamageReduction(damageAfterPercentageReduction);
        return UpdateOpponentHpDueTheDamage(finalDamage);
    }

    protected abstract int CalculateDefenseValue();
    protected abstract double CalculateTotalPercentageReduction();

    private double CalculateInitialDamage(int defenseValue)
    {
        double attackValue = Convert.ToDouble(_attackValue);
        double weaponTriangleBonus = Convert.ToDouble(_attackerWeapon.GetWtb(_defender.Weapon));
        double initialDamage = (attackValue * weaponTriangleBonus) - defenseValue;
        return Math.Max(0, initialDamage);
    }

    private int ApplyExtraDamage(double initialDamage)
    {
        double truncatedInitialDamage = Math.Truncate(initialDamage);
        double totalDamage = truncatedInitialDamage + _extraDamage + _followUpExtraDamage;
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
        int absoluteDamageReduction = _defender.AbsoluteDamageReduction;
        return Math.Max(0, damage - absoluteDamageReduction);
    }
    
    private int UpdateOpponentHpDueTheDamage(double finalDamage)
    {
        int finalDamageInt = Convert.ToInt32(Math.Floor(finalDamage));
        _defender.DecreaseCurrentHpDueDamage(finalDamageInt);
        _attacker.SetFinalCausedDamage(finalDamageInt);
        int attackerHealing = Convert.ToInt32(Math.Floor(finalDamage * _attacker.HealingPercentage));
        _attacker.IncreaseCurrentHpDueHealing(attackerHealing);
        return finalDamageInt;
    }
}
