namespace Fire_Emblem.Weapons;

public class Magic : Weapon
{
    public Magic() { Name = "Magic"; }

    public override double GetWtb(Weapon opponentWeapon)
    {
        return 1.0;
    }
}