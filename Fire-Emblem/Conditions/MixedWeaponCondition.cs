using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Conditions;

public class MixedWeaponCondition : ICondition
{
    private readonly string[] _physicalWeapons;
    private readonly string[] _magicWeapons;

    public MixedWeaponCondition(string[] physicalWeapons, string[] magicWeapons)
    {
        _physicalWeapons = physicalWeapons;
        _magicWeapons = magicWeapons;
    }

    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        bool activatorUsingPhysical = _physicalWeapons.Contains(activator.Weapon.Name);
        bool opponentUsingMagical = _magicWeapons.Contains(opponent.Weapon.Name);

        bool activatorUsingMagical = _magicWeapons.Contains(activator.Weapon.Name);
        bool opponentUsingPhysical = _physicalWeapons.Contains(opponent.Weapon.Name);

        return (activatorUsingPhysical && opponentUsingMagical) || (activatorUsingMagical && opponentUsingPhysical);
    }

    public ICondition Clone()
    {
        return new MixedWeaponCondition(_physicalWeapons, _magicWeapons);
    }
}