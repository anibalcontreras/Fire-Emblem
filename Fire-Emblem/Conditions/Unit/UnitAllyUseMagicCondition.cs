using Fire_Emblem.Units;
using Fire_Emblem.Weapons;

namespace Fire_Emblem.Conditions;

public class UnitAllyUseMagicCondition : ICondition
{
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        Allies activatorAllies = activator.Allies;
        
        IEnumerable<Unit> allies = activatorAllies.Items;
        foreach (Unit ally in allies)
        {
            Weapon allyWeapon = ally.Weapon;
            if (allyWeapon.GetType() == typeof(Magic))
                return true;
        }
        return false;
    }
}