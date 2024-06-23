using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Conditions;

public class UnitAllyUseMagicCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        foreach (Unit ally in activator.Allies)
        {
            if (ally.Weapon.GetType() == typeof(Magic))
                return true;
        }
        return false;
    }
}