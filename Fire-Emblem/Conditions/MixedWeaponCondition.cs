using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class MixedWeaponCondition : ICondition
{
    private readonly string[] _physicalWeapons = { "Bow", "Sword", "Lance", "Axe" };
    private readonly string[] _magicWeapons = { "Magic" };
    
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        bool activatorUsingPhysical = _physicalWeapons.Contains(activator.Weapon.Name);
        bool opponentUsingMagical = _magicWeapons.Contains(opponent.Weapon.Name);
        bool activatorUsingMagical = _magicWeapons.Contains(activator.Weapon.Name);
        bool opponentUsingPhysical = _physicalWeapons.Contains(opponent.Weapon.Name);
        return (activatorUsingPhysical && opponentUsingMagical) 
               || (activatorUsingMagical && opponentUsingPhysical);
    }
}