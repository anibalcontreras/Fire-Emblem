using Fire_Emblem.Controller;

namespace Fire_Emblem.TeamManagment;

using Fire_Emblem.UnitManagment;
using Fire_Emblem.SkillManagment;

public class TeamValidator
{

    private InitGameController _gameController;
    private Dictionary<string, Team> _playerTeams = new Dictionary<string, Team>();
    
    public TeamValidator(InitGameController gameController)
    {
        _gameController = gameController;
    }

    
    public List<Team> BuildTeams(string fileContent)
    {
        var lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
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
        {
            currentPlayer = CreatePlayerIfNecessary(trimmedLine);
        }
        else
        {
            AddUnitToCurrentPlayer(trimmedLine, ref currentPlayer);
        }

        return currentPlayer;
    }

    private Player CreatePlayerIfNecessary(string line)
    {
        string playerName = string.Join(" ", line.Split().Take(2));
        Player player = new Player(playerName);
        _playerTeams[line] = player.Team;
        return player;
    }

    
    // Limpiar
    private void AddUnitToCurrentPlayer(string line, ref Player currentPlayer)
    {
        if (!string.IsNullOrWhiteSpace(line) && currentPlayer != null)
        {
            string[] parts = line.Split('(');
            string unitName = parts[0].Trim();
            // Busca la unidad original en el controlador de juego
            Unit originalUnit = _gameController.Units.FirstOrDefault(u => u.Name == unitName);

            if (originalUnit != null)
            {
                // Clona la unidad original creando una nueva instancia y copiando sus propiedades
                Unit clonedUnit = new Unit
                {
                    Name = originalUnit.Name,
                    Gender = originalUnit.Gender,
                    DeathQuote = originalUnit.DeathQuote,
                    HP = originalUnit.HP,
                    Atk = originalUnit.Atk,
                    Spd = originalUnit.Spd,
                    Def = originalUnit.Def,
                    Res = originalUnit.Res,
                    Weapon = originalUnit.Weapon // Asegúrate de manejar la clonación de objetos complejos adecuadamente
                };
            
                // Inicializa el HP actual de la unidad clonada
                clonedUnit.InitializeCurrentHP();

                // Crea un nuevo UnitLoadout con la unidad clonada
                UnitLoadout unitLoadout = new UnitLoadout(clonedUnit);

                // Procesa y equipa habilidades a la unidad clonada si es necesario
                ProcessUnitSkills(parts, unitLoadout);

                // Añade el UnitLoadout al equipo del jugador actual
                currentPlayer.Team.AddUnitLoadout(unitLoadout);
            }
            else
            {
                Console.WriteLine($"No se encontró la unidad {unitName}");
            }
        }
    }


    private void ProcessUnitSkills(string[] parts, UnitLoadout unitLoadout)
    {
        if (parts.Length > 1)
        {
            string cleanSkills = parts[1].TrimEnd(')').Trim();
            string[] skillNames = cleanSkills.Split(',');

            foreach (string skillName in skillNames)
            {
                string cleanSkillName = skillName.Trim();
                Skill skill = _gameController.Skills.FirstOrDefault(s => s.Name == cleanSkillName);

                if (skill != null)
                    unitLoadout.EquipSkill(skill);
                else
                    Console.WriteLine($"No se encontró la habilidad {cleanSkillName}");
            }
        }
    }
}
