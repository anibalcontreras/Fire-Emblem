using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public interface ICondition
{
    bool IsConditionMet(Unit activator, Unit opponent);
}