using Fire_Emblem.Skills;
using Fire_Emblem.Units;

namespace Fire_Emblem.Teams;
public class Team
{
    private readonly int _minAmountOfUnits = 1;
    private readonly int _maxAmountOfUnits = 3;
    private readonly int _maxAmountOfSkills = 2;
    private readonly int _currentHpBoundary = 0;
    public List<Unit> Units { get; } = new();
    private string _name;
    
    public Team(string name)
    {
        _name = name;
    }
    
    public void AddUnit(Unit unit)
        =>Units.Add(unit);
    
    public bool IsValidTeam()
    {
        return HasValidUnitCount() && HasUniqueUnits() && UnitsHaveValidSkills();
    }
    
    private bool HasValidUnitCount()
    {
        return Units.Count >= _minAmountOfUnits && Units.Count <= _maxAmountOfUnits;
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
                return false;
        }
        return true;
    }

    private bool HasValidNumberOfSkills(Unit unit)
    {
        IEnumerable<Skill> unitSkills = unit.Skills;
        return unitSkills.Count() <= _maxAmountOfSkills;
    }

    private bool HasUniqueSkills(Unit unit)
    {
        IEnumerable<Skill> unitSkills = unit.Skills;
        IEnumerable<string> uniqueSkillNames = GetUniqueSkillNames(unitSkills);
        return uniqueSkillNames.Count() == unitSkills.Count();
    }
    
    private IEnumerable<string> GetUniqueSkillNames(IEnumerable<Skill> equippedSkills)
    {
        List<string> skillNames = new List<string>();
        foreach (Skill skill in equippedSkills)
        {
            string skillName = skill.Name;
            skillNames.Add(skillName);
        }
        IEnumerable<string> uniqueSkillNames = skillNames.Distinct();
        return uniqueSkillNames;
    }
    
    public void RemoveDefeatedUnits()
        => Units.RemoveAll(unit => unit.CurrentHP <= _currentHpBoundary);
    
    public bool HasLivingUnits()
    {
        return Units.Any(unit => unit.CurrentHP > _currentHpBoundary);
    }
}
