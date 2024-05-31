namespace Fire_Emblem.Combats.Weapons;

public class Bow : Weapon
{
    public Bow() { Name = "Bow"; }

    public override double GetWtb(Weapon opponentWeapon)
    {
        return 1.0;
    }
}