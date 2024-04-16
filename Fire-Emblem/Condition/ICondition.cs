using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public interface ICondition
{
    bool IsConditionMet(Unit unit, Combat combat);

    ICondition Clone();
}