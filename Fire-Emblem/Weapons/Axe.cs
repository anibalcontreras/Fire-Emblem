namespace Fire_Emblem.Weapons;

public class Axe : Weapon
{
    private readonly string _weaponName = "Axe";
    public Axe() { Name = _weaponName; }

    public override double GetWtb(Weapon opponentWeapon)
    {
        return opponentWeapon switch
        {
            Lance _ => 1.2,
            Sword _ => 0.8,
            _ => 1.0,
        };
    }
}
