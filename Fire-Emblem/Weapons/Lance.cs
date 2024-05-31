namespace Fire_Emblem.Weapons;

public class Lance : Weapon
{
    public Lance() { Name = "Lance"; }

    public override double GetWtb(Weapon opponentWeapon)
    {
        return opponentWeapon switch
        {
            Sword _ => 1.2,
            Axe _ => 0.8,
            _ => 1.0,
        };
    }
}