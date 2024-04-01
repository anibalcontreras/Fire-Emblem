namespace Fire_Emblem.TeamManagment;

using Fire_Emblem.UnitManagment;

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
            if (unitLoadout.EquippedSkills.Count > 2 || unitLoadout.EquippedSkills.Count != unitLoadout.EquippedSkills.Distinct().Count())
                return false;
        }
        return true;
    }
    
    // Tiene que ser privado (PENSAR)
    public void RemoveDefeatedUnits()
    {
        UnitsLoadout.RemoveAll(unitLoadout => unitLoadout.Unit.CurrentHP <= 0);
    }
    
}