namespace Fire_Emblem.Weapons;

public class Bow : Weapon
{
    public Bow() { Name = "Bow"; }

    public override double GetWtb(Weapon opponentWeapon)
    {
        return 1.0;
    }
}