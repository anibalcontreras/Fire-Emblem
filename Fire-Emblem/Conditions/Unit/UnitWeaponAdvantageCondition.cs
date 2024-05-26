using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Conditions;

public class UnitWeaponAdvantageCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return activator.Weapon.CalculateAdvantage(opponent) == AdvantageState.Advantage;
    }
}
