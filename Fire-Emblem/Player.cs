namespace Fire_Emblem;

using Fire_Emblem.TeamManagment;

public class Player
{
    public string Name { get; set; }
    public Team Team { get; set; }

    public Player(string name)
    {
        Name = name;
        Team = new Team(name);
    }
}