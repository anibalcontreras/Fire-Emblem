using Fire_Emblem.SkillManagment;

namespace Fire_Emblem.TeamManagment;
public class Team
{
    public List<UnitLoadout> UnitsLoadout { get; set; } = new List<UnitLoadout>();
    public string Name { get; private set; }
    
    
    public Team(string name)
    {
        Name = name;
    }
    
    public void AddUnitLoadout(UnitLoadout unitLoadout)
        =>UnitsLoadout.Add(unitLoadout);
    

    public bool IsValidTeam()
    {
        return HasValidUnitCount() && HasUniqueUnits() && UnitsHaveValidSkills();
    }
    
    private bool HasValidUnitCount()
    {
        return UnitsLoadout.Count >= 1 && UnitsLoadout.Count <= 3;
    }
    
    private bool HasUniqueUnits()
    {
        IEnumerable<string> unitNames = UnitsLoadout.Select(unitLoadout => unitLoadout.Unit.Name);
        return unitNames.Distinct().Count() == unitNames.Count();
    }
    
    private bool UnitsHaveValidSkills()
    {
        foreach (UnitLoadout unitLoadout in UnitsLoadout)
        {
            if (!HasValidNumberOfSkills(unitLoadout) || !HasUniqueSkills(unitLoadout))
            {
                return false;
            }
        }
        return true;
    }

    private bool HasValidNumberOfSkills(UnitLoadout unitLoadout)
    {
        return unitLoadout.EquippedSkills.Count <= 2;
    }

    private bool HasUniqueSkills(UnitLoadout unitLoadout)
    {
        var uniqueSkillNames = GetUniqueSkillNames(unitLoadout.EquippedSkills);
        return uniqueSkillNames.Count() == unitLoadout.EquippedSkills.Count;
    }
    
    private IEnumerable<string> GetUniqueSkillNames(IEnumerable<Skill> equippedSkills)
    {
        return equippedSkills.Select(skill => skill.Name).Distinct();
    }
    
    public void RemoveDefeatedUnits()
    {
        UnitsLoadout.RemoveAll(unitLoadout => unitLoadout.Unit.CurrentHP <= 0);
    }
}
