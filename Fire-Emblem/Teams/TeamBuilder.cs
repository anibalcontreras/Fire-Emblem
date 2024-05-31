using System.Collections.ObjectModel;
using Fire_Emblem.Exception;
using Fire_Emblem.Loaders;

namespace Fire_Emblem.Teams;
using Units;
using Skills;

public class TeamBuilder
{

    private DataLoader _dataLoader;
    private Dictionary<string, Team> _playerTeams = new Dictionary<string, Team>();
    
    public TeamBuilder()
    {
        _dataLoader = new DataLoader();
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
        Player currentPlayer = null;

        foreach (var line in lines)
        {
            currentPlayer = ProcessLine(line, currentPlayer);
        }

        return _playerTeams.Values.ToList();
    }

    private Player ProcessLine(string line, Player currentPlayer)
    {
        string trimmedLine = line.Trim();
        if (trimmedLine.StartsWith("Player"))
            currentPlayer = CreatePlayerIfNecessary(trimmedLine);
        else
            AddUnitToCurrentPlayer(trimmedLine, ref currentPlayer);

        return currentPlayer;
    }

    private Player CreatePlayerIfNecessary(string line)
    {
        string playerName = string.Join(" ", line.Split().Take(2));
        Player player = new Player(playerName);
        _playerTeams[line] = player.Team;
        return player;
    }
    
    private void AddUnitToCurrentPlayer(string line, ref Player currentPlayer)
    {
        if (string.IsNullOrWhiteSpace(line))
            return;

        string unitName = ExtractUnitName(line);
        Unit originalUnit = FindUnitByName(unitName);
        Unit clonedUnit = CloneUnit(originalUnit);
        AddUnitToPlayer(clonedUnit, line, ref currentPlayer);
    }

    private string ExtractUnitName(string line)
    {
        string[] parts = line.Split('(');
        return parts[0].Trim();
    }

    private Unit FindUnitByName(string unitName)
    {
        IEnumerable<Unit> AvailableUnits = _dataLoader.Units;
        
        Unit foundUnit = AvailableUnits.FirstOrDefault(unit => 
            unit.Name.Equals(unitName, StringComparison.OrdinalIgnoreCase));
        
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

    private void AddUnitToPlayer(Unit clonedUnit, string line, ref Player currentPlayer)
    {
        clonedUnit.InitializeCurrentHp();
        Unit unit = clonedUnit;
        
        ProcessUnitSkills(line.Split('('), unit);
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
        string cleanSkills = skillsPart.TrimEnd(')').Trim();
        return cleanSkills.Split(',').Select(skillName => skillName.Trim());
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
        
        Skill clonedSkill = new Skill(skill.Name, skill.Effect);
        
        unit.AddSkill(clonedSkill);
    }

    private Skill FindSkillByName(string skillName)
    {
        ReadOnlyCollection<Skill> dataLoaderSkills = _dataLoader.Skills;
        
        return dataLoaderSkills.FirstOrDefault(skill => skill.Name == skillName);
    }
}
