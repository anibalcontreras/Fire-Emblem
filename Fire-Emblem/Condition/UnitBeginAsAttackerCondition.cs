using Fire_Emblem.TeamManagment;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class UnitBeginAsAttackerCondition : ICondition
{
    private readonly string _skillName;
    public UnitBeginAsAttackerCondition(string skillName)
    {
        _skillName = skillName;
    }
    
    public bool IsConditionMet(Combat combat)
    {
        Console.WriteLine("Checking if unit begins as attacker");
        Console.WriteLine("Attacker: " + combat.Attacker.Name);
        Console.WriteLine("Skill name: " + _skillName);
        
        // Check if the attacker have the skillName as the skill that triggers the effect

        foreach (var skill in combat.Attacker.Skills)
        {
            if (skill.Name == _skillName) 
                return true;
        }
        
        return false;
    }
    
    public ICondition Clone()
    {
        return new UnitBeginAsAttackerCondition(_skillName);
    }
}