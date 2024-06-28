using Fire_Emblem_GUI;
using Fire_Emblem_View;

namespace Fire_Emblem.Views;

public class GraphicGameView : BaseGameView
{
    private readonly FireEmblemWindow _window;

    public GraphicGameView(FireEmblemWindow window)
    {
        _window = window;
    }

    public override string GetTeam1()
    {
        return _window.GetTeam1();
    }
    
    public override string GetTeam2()
    {
        return _window.GetTeam2();
    }

    public override void ShowInvalidTeamMessage()
    {
        _window.ShowInvalidTeamMessage();
    }


    public void UpdateTeams(IUnit[] unit1, IUnit[] unit2)
    {
        _window.UpdateTeams(unit1, unit2);
    }
}
