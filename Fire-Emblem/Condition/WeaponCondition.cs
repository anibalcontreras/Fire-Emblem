using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class WeaponCondition : ICondition
{
    private readonly string _requiredWeaponName;

    public WeaponCondition(string requiredWeaponName)
    {
        _requiredWeaponName = requiredWeaponName;
    }

    public bool IsConditionMet(Unit unit, Combat combat)
    {
        return unit.Weapon.Name == _requiredWeaponName;
    }

    public ICondition Clone()
    {
        return new WeaponCondition(_requiredWeaponName);
    }
}