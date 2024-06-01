using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Conditions;

public class RivalWeaponCondition : ICondition
{
    private readonly List<string> _requiredWeaponNames;
    public RivalWeaponCondition(params string[] requiredWeaponNames)
    {
        _requiredWeaponNames = requiredWeaponNames.ToList();
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        Weapon opponentWeapon = opponent.Weapon;
        return _requiredWeaponNames.Contains(opponentWeapon.Name);
    }
}