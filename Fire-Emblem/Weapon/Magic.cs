namespace Fire_Emblem.Weapon;

public class Magic : Weapon
{
    public Magic() { Name = "Magic"; }

    public override double GetWTB(Weapon opponentWeapon)
    {
        return 1.0;  // Sin ventaja ni desventaja contra cualquier arma
    }
}