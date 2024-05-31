using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions;

public class MixedWeaponCondition : ICondition
{
    private readonly string[] _physicalWeapons;
    private readonly string[] _magicWeapons;

    public MixedWeaponCondition(string[] physicalWeapons, string[] magicWeapons)
    {
        _physicalWeapons = physicalWeapons;
        _magicWeapons = magicWeapons;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        bool activatorUsingPhysical = _physicalWeapons.Contains(activator.Weapon.Name);
        bool opponentUsingMagical = _magicWeapons.Contains(opponent.Weapon.Name);

        bool activatorUsingMagical = _magicWeapons.Contains(activator.Weapon.Name);
        bool opponentUsingPhysical = _physicalWeapons.Contains(opponent.Weapon.Name);

        return (activatorUsingPhysical && opponentUsingMagical) || (activatorUsingMagical && opponentUsingPhysical);
    }
}