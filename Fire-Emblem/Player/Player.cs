using Fire_Emblem.TeamManagment;

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