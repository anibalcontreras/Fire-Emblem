using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public interface IBonusEffect
{
    void ApplyBonus(GameView view, Unit activator, Unit opponent);
    void RevertBonus(GameView view, Unit activator, Unit opponent);
}