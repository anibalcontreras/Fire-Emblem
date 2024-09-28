namespace Fire_Emblem.Weapons;

public class Magic : Weapon
{
    private readonly string _weaponName = "Magic";
    public Magic() { Name = _weaponName; }

    public override double GetWtb(Weapon opponentWeapon)
    {
        return 1.0;
    }
}