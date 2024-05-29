using Fire_Emblem.Skills;
using Fire_Emblem.Units;

namespace Fire_Emblem.Teams;
public class Team
{
    public List<Unit> Units { get; } = new List<Unit>();
    public string Name { get; private set; }
    
    public Team(string name)
    {
        Name = name;
    }
    
    public void AddUnit(Unit unit)
        =>Units.Add(unit);
    
    public bool IsValidTeam()
    {
        return HasValidUnitCount() && HasUniqueUnits() && UnitsHaveValidSkills();
    }
    
    private bool HasValidUnitCount()
    {
        return Units.Count >= 1 && Units.Count <= 3;
    }
    
    private bool HasUniqueUnits()
    {
        IEnumerable<string> unitNames = Units.Select(unit => unit.Name);
        IEnumerable<string> distinctUnitNames = unitNames.Distinct();
        bool hasUniqueUnits = distinctUnitNames.Count() == unitNames.Count();
        return hasUniqueUnits;
    }
    
    private bool UnitsHaveValidSkills()
    {
        foreach (Unit unit in Units)
        {
            if (!HasValidNumberOfSkills(unit) || !HasUniqueSkills(unit))
            {
                return false;
            }
        }
        return true;
    }

    private bool HasValidNumberOfSkills(Unit unit)
    {
        return unit.Skills.Count() <= 2;
    }

    private bool HasUniqueSkills(Unit unit)
    {
        var uniqueSkillNames = GetUniqueSkillNames(unit.Skills);
        return uniqueSkillNames.Count() == unit.Skills.Count();
    }
    
    private IEnumerable<string> GetUniqueSkillNames(IEnumerable<Skill> equippedSkills)
    {
        return equippedSkills.Select(skill => skill.Name).Distinct();
    }
    
    public void RemoveDefeatedUnits()
    {
        Units.RemoveAll(unit => unit.CurrentHP <= 0);
    }
    
    public bool HasLivingUnits()
    {
        return Units.Any(unit => unit.CurrentHP > 0);
    }
}
