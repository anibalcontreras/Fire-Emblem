using Fire_Emblem.Units;

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
        return activator.Weapon.GetType() == _requiredWeaponType;
    }
}


