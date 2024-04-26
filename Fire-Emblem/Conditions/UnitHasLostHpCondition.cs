using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class UnitHasLostHpCondition : ICondition
{
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return activator.CurrentHP < activator.BaseHp;
    }

    public ICondition Clone()
    {
        return new UnitHasLostHpCondition();
    }
}