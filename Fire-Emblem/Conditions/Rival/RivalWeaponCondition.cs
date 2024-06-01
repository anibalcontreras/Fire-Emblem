using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Conditions;

public class RivalWeaponCondition : ICondition
{
    private readonly List<Type> _requiredWeaponTypes;

    public RivalWeaponCondition(params Type[] requiredWeaponTypes)
    {
        _requiredWeaponTypes = requiredWeaponTypes.ToList();
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return _requiredWeaponTypes.Contains(opponent.Weapon.GetType());
    }
}