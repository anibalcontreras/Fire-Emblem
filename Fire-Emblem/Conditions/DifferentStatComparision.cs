using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class DifferentStatComparision : ICondition
{
    private readonly StatType _firstStatType;
    private readonly StatType _secondStatType;

    public DifferentStatComparision(StatType firstStatType, StatType secondStatType)
    {
        _firstStatType = firstStatType;
        _secondStatType = secondStatType;
    }

    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        int activatorStatValue = GetStatValue(activator, _firstStatType);
        int opponentStatValue = GetStatValue(opponent, _secondStatType);
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
