using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class UnitHasLostHpCondition : ICondition
{
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        return activator.CurrentHP < activator.HP;
    }

    public ICondition Clone()
    {
        return new UnitHasLostHpCondition();
    }
}