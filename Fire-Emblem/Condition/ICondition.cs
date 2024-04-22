using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public interface ICondition
{
    bool IsConditionMet(Combat combat, Unit activator, Unit opponent);

    ICondition Clone();
}