using Fire_Emblem.Condition;
using Fire_Emblem.Effect;
using Fire_Emblem.Loader;

namespace Fire_Emblem.TeamManagment;

using Fire_Emblem.UnitManagment;
using Fire_Emblem.SkillManagment;

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
        if (string.IsNullOrWhiteSpace(line) || currentPlayer == null)
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
        return _dataLoader.Units.FirstOrDefault(u => u.Name == unitName);
    }

    private Unit CloneUnit(Unit originalUnit)
    {
        return new Unit
        {
            Name = originalUnit.Name,
            Gender = originalUnit.Gender,
            DeathQuote = originalUnit.DeathQuote,
            HP = originalUnit.HP,
            Atk = originalUnit.Atk,
            Spd = originalUnit.Spd,
            Def = originalUnit.Def,
            Res = originalUnit.Res,
            Weapon = originalUnit.Weapon
        };
    }

    private void AddUnitToPlayer(Unit clonedUnit, string line, ref Player currentPlayer)
    {
        clonedUnit.InitializeCurrentHP();
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
        // TODO: Acá se tiene este parche mientras no están todas las skills programadas y tenga que pasar los primeros tests
        Skill skill = null;
        try
        {
            skill = SkillFactory.CreateSkill(skillName);
        }
        catch (ArgumentException)
        {
            skill = FindSkillByName(skillName);
        }
        
        Skill clonedSkill = new Skill(skill.Name, skill.Condition, skill.Effect);
        
        unit.AddSkill(clonedSkill);
    }

    private Skill FindSkillByName(string skillName)
    {
        return _dataLoader.Skills.FirstOrDefault(s => s.Name == skillName);
    }
    
}
