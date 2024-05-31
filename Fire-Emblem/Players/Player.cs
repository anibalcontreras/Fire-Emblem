using Fire_Emblem.Combats.Teams;

namespace Fire_Emblem.Combats;
public class Player
{
    public string Name { get; private set; }
    public Team Team { get; }

    public Player(string name)
    {
        Name = name;
        Team = new Team(name);
    }
}