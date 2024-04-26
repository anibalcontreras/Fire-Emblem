using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class UnitWeaponCondition : ICondition
{
    private readonly string _requiredWeaponName;

    public UnitWeaponCondition(string requiredWeaponName)
    {
        _requiredWeaponName = requiredWeaponName;
    }

    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return activator.Weapon.Name == _requiredWeaponName;
    }


    public ICondition Clone()
    {
        return new UnitWeaponCondition(_requiredWeaponName);
    }
}