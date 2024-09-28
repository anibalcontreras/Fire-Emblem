using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Conditions;

public class MixedWeaponCondition : ICondition
{
    private readonly string[] _physicalWeapons = { "Bow", "Sword", "Lance", "Axe" };
    private readonly string[] _magicWeapons = { "Magic" };

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return (IsPhysicalWeapon(activator.Weapon) && IsMagicalWeapon(opponent.Weapon)) 
               || (IsMagicalWeapon(activator.Weapon) && IsPhysicalWeapon(opponent.Weapon));
    }

    private bool IsPhysicalWeapon(Weapon weapon)
    {
        return _physicalWeapons.Contains(weapon.Name);
    }

    private bool IsMagicalWeapon(Weapon weapon)
    {
        return _magicWeapons.Contains(weapon.Name);
    }
}
