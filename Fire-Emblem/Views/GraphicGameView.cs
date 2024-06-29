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
    
    public override void UpdateTeams(IUnit[] unit1, IUnit[] unit2)
    {
        _window.UpdateTeams(unit1, unit2);
    }
    
    public override int SelectUnitFirstTeam()
    {
        return _window.SelectUnitTeam1();
    }
    
    public override int SelectUnitSecondTeam()
    {
        return _window.SelectUnitTeam2();
    }
    
    public override void ShowAttackFromTeam1(IUnit unit1, IUnit unit2)
    {
        _window.ShowAttackFromTeam1(unit1, unit2);
    }
    
    public override void ShowAttackFromTeam2(IUnit unit1, IUnit unit2)
    {
        _window.ShowAttackFromTeam2(unit1, unit2);
    }
    
    public override void UpdateUnitsStatsDuringBattle(IUnit unit1, IUnit unit2)
    {
        _window.UpdateUnitsStatsDuringBattle(unit1, unit2);
    }
    
    public override void CongratulateTeam1(IUnit[] winnerTeam)
    {
        _window.CongratulateTeam1(winnerTeam);
    }
    
}
