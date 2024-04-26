using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public interface ICondition
{
    bool IsConditionMet(Combat combat, Unit activator, Unit opponent);

    ICondition Clone();
}