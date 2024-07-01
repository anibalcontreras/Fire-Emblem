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
        Weapon opponentWeapon = opponent.Weapon;
        return _requiredWeaponTypes.Contains(opponentWeapon.GetType());
    }
}