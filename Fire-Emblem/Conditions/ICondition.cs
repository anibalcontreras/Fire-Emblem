using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Conditions;

public interface ICondition
{
    bool IsConditionMet(Unit activator, Unit opponent);
}