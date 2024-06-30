using System.Collections.ObjectModel;
using Fire_Emblem.Exception;
using Fire_Emblem.Loaders;
using Fire_Emblem.Players;
using Fire_Emblem.Units;
using Fire_Emblem.Skills;

namespace Fire_Emblem.Teams;

public class TeamBuilder
{

    private readonly DataLoader _dataLoader;
    private readonly PlayerTeams _playerTeams;
    
    public TeamBuilder()
    {
        _dataLoader = new DataLoader();
        _playerTeams = new PlayerTeams();
    }
    
    public List<Team> BuildTeams(string fileContent)
    {
        string[] lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        List<Team> playerTeams = BuildPlayerTeamsFromFileTxt(lines);
        return playerTeams;
    }
    
    private List<Team> BuildPlayerTeamsFromFileTxt(string[] lines)
    {
        _playerTeams.Clear();
        Player currentPlayer = new Player();
        foreach (string line in lines)
        {
            currentPlayer = ProcessFileLine(line, currentPlayer);
        }

        return _playerTeams.GetTeams();
    }

    private Player ProcessFileLine(string line, Player currentPlayer)
    {
        string trimmedLine = line.Trim();
        if (trimmedLine.StartsWith("Player"))
            currentPlayer = CreatePlayerIfNecessary(trimmedLine);
        else
            AddUnitToCurrentPlayer(trimmedLine, ref currentPlayer);
        return currentPlayer;
    }

    private Player CreatePlayerIfNecessary(string playerLine)
    {
        Player player = new Player();
        _playerTeams.AddTeam(playerLine, player.Team);
        return player;
    }
    
    private void AddUnitToCurrentPlayer(string playerLine, ref Player currentPlayer)
    {
        if (string.IsNullOrWhiteSpace(playerLine))
            return;
        string unitName = ExtractUnitName(playerLine);
        Unit originalUnit = FindUnitByName(unitName);
        Unit clonedUnit = CloneUnit(originalUnit);
        AddUnitToPlayer(clonedUnit, playerLine, ref currentPlayer);
    }

    private string ExtractUnitName(string unitLine)
    {
        string[] parts = unitLine.Split('(');
        return parts[0].Trim();
    }

    private Unit FindUnitByName(string unitName)
    {
        IEnumerable<Unit> availableUnits = _dataLoader.Units;
        var foundUnit = IterateInAvailableUnits(unitName, availableUnits);
        return foundUnit;
    }

    private Unit IterateInAvailableUnits(string unitName, IEnumerable<Unit> availableUnits)
    {
        Unit foundUnit = new Unit();
        foreach (Unit unit in availableUnits)
        {
            string foundUnitName = unit.Name;
            if (foundUnitName.Equals(unitName, StringComparison.OrdinalIgnoreCase))
                foundUnit = unit;
        }
        return foundUnit;
    }

    private Unit CloneUnit(Unit originalUnit)
    {
        return new Unit
        {
            Name = originalUnit.Name,
            Gender = originalUnit.Gender,
            DeathQuote = originalUnit.DeathQuote,
            BaseHp = originalUnit.BaseHp,
            BaseAtk = originalUnit.BaseAtk,
            BaseSpd = originalUnit.BaseSpd,
            BaseDef = originalUnit.BaseDef,
            BaseRes = originalUnit.BaseRes,
            Weapon = originalUnit.Weapon
        };
    }

    private void AddUnitToPlayer(Unit clonedUnit, string unitLine, ref Player currentPlayer)
    {
        clonedUnit.InitializeCurrentHp();
        Unit unit = clonedUnit;
        ProcessUnitSkills(unitLine.Split('('), unit);
        currentPlayer.Team.AddUnit(unit);
    }
    
    private void ProcessUnitSkills(string[] parts, Unit unit)
    {
        if (parts.Length <= 1) return;
        IEnumerable<string> skillNames = ExtractSkillNames(parts[1]);
        foreach (string skillName in skillNames)
        {
            EquipSkillByName(skillName, unit);
        }
    }

    private IEnumerable<string> ExtractSkillNames(string skillsPart)
    {
        string cleanSkills = skillsPart.TrimEnd(')');
        cleanSkills = cleanSkills.Trim();
        string[] skillNames = cleanSkills.Split(',');
        for (int i = 0; i < skillNames.Length; i++)
        {
            skillNames[i] = skillNames[i].Trim();
        }
        return skillNames;
    }

    private void EquipSkillByName(string skillName, Unit unit)
    {
        Skill skill;
        SkillFactory skillFactory = new SkillFactory();
        try
        {
            skill = skillFactory.CreateSkill(skillName);
        }
        catch (NotImplementedSkillException)
        {
            skill = FindSkillByName(skillName);
        }
        SkillsList unitSkills = unit.Skills;
        Skill clonedSkill = new Skill(skill.Name, skill.Effect);
        unitSkills.AddSkill(clonedSkill);
    }

    private Skill FindSkillByName(string skillName)
    {
        ReadOnlyCollection<Skill> dataLoaderSkills = _dataLoader.Skills;
        return dataLoaderSkills.FirstOrDefault(skill => skill.Name == skillName);
    }
}
