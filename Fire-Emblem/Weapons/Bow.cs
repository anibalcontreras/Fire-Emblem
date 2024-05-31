namespace Fire_Emblem.Weapons;

public class Bow : Weapon
{
    private readonly string _weaponName = "Bow";
    public Bow() { Name = _weaponName; }

    public override double GetWtb(Weapon opponentWeapon)
    {
        return 1.0;
    }
}