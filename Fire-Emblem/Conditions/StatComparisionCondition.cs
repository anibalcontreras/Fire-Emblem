using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class StatComparisionCondition : ICondition
{
    private readonly StatType _statType;

    public StatComparisionCondition(StatType statType)
    {
        _statType = statType;
    }

    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        int activatorStatValue = GetStatValue(activator, _statType);
        int opponentStatValue = GetStatValue(opponent, _statType);
        return activatorStatValue > opponentStatValue;
    }

    private int GetStatValue(Unit unit, StatType statType)
    {
        switch (statType)
        {
            case StatType.Res:
                return unit.CurrentRes;
            case StatType.Atk:
                return unit.CurrentAtk;
            case StatType.Def:
                return unit.CurrentDef;
            case StatType.Spd:
                return unit.CurrentSpd;
            case StatType.HP:
                return unit.CurrentHP;
            default:
                throw new ArgumentOutOfRangeException(nameof(statType), statType, "Invalid stat type.");
        }
    }
}
