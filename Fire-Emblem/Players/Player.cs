using Fire_Emblem.Teams;

namespace Fire_Emblem;
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