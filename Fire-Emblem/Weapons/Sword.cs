namespace Fire_Emblem.Combats.Weapons;

public class Sword : Weapon
{
    public Sword()
    {
        Name = "Sword"; 
    }
    
    public override double GetWtb(Weapon opponentWeapon)
    {
        return opponentWeapon switch
        {
            Axe _ => 1.2,
            Lance _ => 0.8,
            _ => 1.0
        };
    }
}