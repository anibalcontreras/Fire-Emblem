using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class RivalIsManCondition: ICondition
{
    private const string _rivalGender = "Male";
    public bool IsConditionMet(Combat combat, Unit activator, Unit opponent)
    {
        if (opponent.Gender == _rivalGender)
        {
            return true;
        }
        return false;
    }
    
    public ICondition Clone()
    {
        return new RivalIsManCondition();
    }
}