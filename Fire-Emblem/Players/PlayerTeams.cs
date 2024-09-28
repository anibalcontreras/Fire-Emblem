using Fire_Emblem.Teams;

namespace Fire_Emblem.Players;

public class PlayerTeams
{
    private readonly Dictionary<string, Team> _playerTeams = new();
    
    public void Clear()
    {
        _playerTeams.Clear();
    }

    public void AddTeam(string playerName, Team team)
    {
        _playerTeams[playerName] = team;
    }

    public List<Team> GetTeams()
    {
        var playerTeamsValues = _playerTeams.Values;
        return playerTeamsValues.ToList();
    }
    
}