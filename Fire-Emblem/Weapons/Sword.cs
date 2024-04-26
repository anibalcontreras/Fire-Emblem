namespace Fire_Emblem.Weapons;

public class Sword : Weapon
{
    public Sword()
    {
        Name = "Sword"; 
    }
    
    public override double GetWTB(Weapon opponentWeapon)
    {
        return opponentWeapon switch
        {
            Axe _ => 1.2,  // Ventaja sobre la hacha
            Lance _ => 0.8,  // Desventaja contra la lanza
            _ => 1.0,  // Sin ventaja ni desventaja contra otros tipos de armas
        };
    }
}