using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Weapon;

public abstract class Weapon
{
    public string Name { get; set; }
    public AdvantageState CalculateAdvantage(Unit attacker, Unit defender)
    {
        double wtb = GetWTB(defender.Weapon);

        if (wtb > 1.0)
            return AdvantageState.Advantage;
        else if (wtb < 1.0)
            return AdvantageState.Disadvantage;
        else
            return AdvantageState.Neutral;
    }
    public abstract double GetWTB(Weapon opponentWeapon);

}