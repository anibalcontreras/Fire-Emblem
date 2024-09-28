using Fire_Emblem_GUI;

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


    public override void UpdateTeams(IUnit[] firstUnit, IUnit[] secondUnit)
    {
        _window.UpdateTeams(firstUnit, secondUnit);
    }
    
    public override int SelectUnitFirstTeam()
    {
        return _window.SelectUnitTeam1();
    }
    
    public override int SelectUnitSecondTeam()
    {
        return _window.SelectUnitTeam2();
    }

    public override void UpdateUnitsStatsDuringBattle(IUnit firstUnit, IUnit secondUnit)
    {
        _window.UpdateUnitsStatsDuringBattle(firstUnit, secondUnit);
    }
}

