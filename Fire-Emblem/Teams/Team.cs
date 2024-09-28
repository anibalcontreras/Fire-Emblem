using Fire_Emblem.Exception;
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
    
    public void AddUnit(Unit unit)
        => Units.Add(unit);

    public void ValidateTeam()
    {
        ValidateUnitCount();
        ValidateUniqueUnits();
        ValidateUnitSkills();
    }

    private void ValidateUnitCount()
    {
        if (Units.Count < _minAmountOfUnits || Units.Count > _maxAmountOfUnits)
        {
            throw new InvalidUnitCountException(_minAmountOfUnits, _maxAmountOfUnits, Units.Count);
        }
    }

    private void ValidateUniqueUnits()
    {
        IEnumerable<string> unitNames = Units.Select(unit => unit.Name);
        IEnumerable<string> distinctUnitNames = unitNames.Distinct();
        if (distinctUnitNames.Count() != unitNames.Count())
        { throw new NonUniqueUnitsException(); }
    }

    private void ValidateUnitSkills()
    {
        foreach (Unit unit in Units)
        {
            ValidateNumberOfSkills(unit);
            ValidateUniqueSkills(unit);
        }
    }

    private void ValidateNumberOfSkills(Unit unit)
    {
        SkillCollection skills = unit.Skills;
        if (skills.Count() > _maxAmountOfSkills)
        {
            throw new TooManySkillsException(unit.Name, _maxAmountOfSkills, skills.Count());
        }
    }

    private void ValidateUniqueSkills(Unit unit)
    {
        SkillCollection unitSkills = unit.Skills;
        IEnumerable<string> uniqueSkillNames = GetUniqueSkillNames(unitSkills);
        if (uniqueSkillNames.Count() != unitSkills.Count())
        {
            throw new NonUniqueSkillsException(unit.Name);
        }
    }

    private IEnumerable<string> GetUniqueSkillNames(SkillCollection equippedSkills)
    {
        List<string> skillNames = new List<string>();
        IEnumerable<Skill> skills = equippedSkills.Items;
        foreach (Skill skill in skills)
        {
            string skillName = skill.Name;
            skillNames.Add(skillName);
        }
        return skillNames.Distinct();
    }

    public void RemoveDefeatedUnits()
        => Units.RemoveAll(unit => unit.CurrentHP <= _currentHpBoundary);

    public bool HasLivingUnits()
    {
        return Units.Any(unit => unit.CurrentHP > _currentHpBoundary);
    }

    public void AddAllies(Unit unit)
    {
        Allies allies = unit.Allies;
        allies.RemoveAllAlies();
        foreach (Unit ally in Units)
        {
            AddTheRightUnitToAllies(unit, ally);
        }
    }

    private void AddTheRightUnitToAllies(Unit unit, Unit ally)
    {
        Allies allies = unit.Allies;
        if (ally != unit)
        {
            allies.AddAlly(ally);
        }
    }
}
