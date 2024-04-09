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
        {
            return; // Salida temprana si la línea está vacía o no hay un jugador actual
        }

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
        UnitLoadout unitLoadout = new UnitLoadout(clonedUnit);
        ProcessUnitSkills(line.Split('('), unitLoadout);
        currentPlayer.Team.AddUnitLoadout(unitLoadout);
    }
    
    private void ProcessUnitSkills(string[] parts, UnitLoadout unitLoadout)
    {
        if (parts.Length <= 1) return;

        IEnumerable<string> skillNames = ExtractSkillNames(parts[1]);
        foreach (string skillName in skillNames)
        {
            EquipSkillByName(skillName, unitLoadout);
        }
    }

    private IEnumerable<string> ExtractSkillNames(string skillsPart)
    {
        string cleanSkills = skillsPart.TrimEnd(')').Trim();
        return cleanSkills.Split(',').Select(skillName => skillName.Trim());
    }

    private void EquipSkillByName(string skillName, UnitLoadout unitLoadout)
    {
        Skill skill = FindSkillByName(skillName);
        Skill clonedSkill = CloneSkill(skill);
        
        unitLoadout.EquipSkill(clonedSkill);
    }

    private Skill FindSkillByName(string skillName)
    {
        return _dataLoader.Skills.FirstOrDefault(s => s.Name == skillName);
    }

    private Skill CloneSkill(Skill originalSkill)
    {
        return new Skill(originalSkill.Name, originalSkill.Description);
    }
}
