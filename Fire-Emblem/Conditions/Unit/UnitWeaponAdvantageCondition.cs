using Fire_Emblem.Combats.Units;
using Fire_Emblem.Combats.Weapons;

namespace Fire_Emblem.Combats.Conditions;

public class UnitWeaponAdvantageCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        return activator.Weapon.CalculateAdvantage(opponent) == AdvantageState.Advantage;
    }
}
