using Fire_Emblem.Units;

namespace Fire_Emblem.Conditions;

public class RivalIsManCondition: ICondition
{
    private const string _rivalGender = "Male";
    public bool IsConditionMet(Unit activator, Unit opponent)
    {
        if (opponent.Gender == _rivalGender)
            return true;
        return false;
    }
}