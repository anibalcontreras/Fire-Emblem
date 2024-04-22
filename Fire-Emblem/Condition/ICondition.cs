using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public interface ICondition
{
    bool IsConditionMet(Combat combat);

    ICondition Clone();
}