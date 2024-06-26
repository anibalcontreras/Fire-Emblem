namespace Fire_Emblem.Teams;

public class TeamCollection
{
    private readonly List<Team> _teams;
    
    public TeamCollection()
    {
        _teams = new List<Team>();
    }

    public void AddTeam(Team team)
        => _teams.Add(team);
    
    public List<Team> GetTeams()
    {
        return new List<Team>(_teams);
    }

    public bool AreTeamsValid()
    {
        return _teams.All(team => team.IsValidTeam());
    }
    
}