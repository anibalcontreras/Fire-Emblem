using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class RivalWeaponCondition : ICondition
{
    private readonly List<string> _requiredWeaponNames;

    public RivalWeaponCondition(params string[] requiredWeaponNames)
    {
        _requiredWeaponNames = requiredWeaponNames.ToList();
    }

    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return _requiredWeaponNames.Contains(opponent.Weapon.Name);
    }
}