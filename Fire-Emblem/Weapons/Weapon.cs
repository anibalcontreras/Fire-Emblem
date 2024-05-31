using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Weapons;

public abstract class Weapon
{
    public string Name { get; set; }
    public AdvantageState CalculateAdvantage(Unit defender)
    {
        double wtb = GetWtb(defender.Weapon);

        if (wtb > 1.0)
            return AdvantageState.Advantage;
        else if (wtb < 1.0)
            return AdvantageState.Disadvantage;
        else
            return AdvantageState.Neutral;
    }
    public abstract double GetWtb(Weapon opponentWeapon);

}