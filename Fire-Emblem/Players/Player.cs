using Fire_Emblem.Teams;

namespace Fire_Emblem.Players;
public class Player
{
    public Team Team { get; }
    public Player()
    {
        Team = new Team();
    }
}