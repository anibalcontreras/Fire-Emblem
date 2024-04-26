namespace Fire_Emblem.Weapons;

public class Lance : Weapon
{
    public Lance() { Name = "Lance"; }

    public override double GetWTB(Weapon opponentWeapon)
    {
        return opponentWeapon switch
        {
            Sword _ => 1.2,  // Ventaja sobre la lanza
            Axe _ => 0.8,  // Desventaja contra la espada
            _ => 1.0,  // Sin ventaja ni desventaja contra otros tipos de armas
        };
    }
}