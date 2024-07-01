using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Conditions;

public class UnitWeaponCondition : ICondition
{
    private readonly Type _requiredWeaponType;

    public UnitWeaponCondition(Type requiredWeaponType)
    {
        _requiredWeaponType = requiredWeaponType;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        Weapon activatorWeapon = activator.Weapon;
        return activatorWeapon.GetType() == _requiredWeaponType;
    }
}


