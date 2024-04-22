using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class UnitWeaponCondition : ICondition
{
    private readonly string _requiredWeaponName;

    public UnitWeaponCondition(string requiredWeaponName)
    {
        _requiredWeaponName = requiredWeaponName;
    }

    public bool IsConditionMet(Combat combat)
    {
        return combat.Attacker.Weapon.Name == _requiredWeaponName;
    }

    public ICondition Clone()
    {
        return new UnitWeaponCondition(_requiredWeaponName);
    }
}