namespace Fire_Emblem.Weapons;

public class Bow : Weapon
{
    public Bow() { Name = "Bow"; }

    public override double GetWTB(Weapon opponentWeapon)
    {
        return 1.0;  // Sin ventaja ni desventaja contra cualquier arma
    }
}