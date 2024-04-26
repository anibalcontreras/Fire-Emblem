namespace Fire_Emblem.Weapons;

public class Axe : Weapon
{
    public Axe() { Name = "Axe"; }

    public override double GetWTB(Weapon opponentWeapon)
    {
        return opponentWeapon switch
        {
            Lance _ => 1.2,  // Ventaja sobre la lanza
            Sword _ => 0.8,  // Desventaja contra la espada
            _ => 1.0,  // Sin ventaja ni desventaja contra otros tipos de armas
        };
    }
}
