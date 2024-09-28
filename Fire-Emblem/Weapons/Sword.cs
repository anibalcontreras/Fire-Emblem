namespace Fire_Emblem.Weapons;

public class Sword : Weapon
{
    private readonly string _weaponName = "Sword";
    public Sword() { Name = _weaponName; }
    
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