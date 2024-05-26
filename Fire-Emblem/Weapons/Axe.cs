namespace Fire_Emblem.Weapons;

public class Axe : Weapon
{
    public Axe() { Name = "Axe"; }

    public override double GetWTB(Weapon opponentWeapon)
    {
        return opponentWeapon switch
        {
            Lance _ => 1.2,
            Sword _ => 0.8,
            _ => 1.0,
        };
    }
}
