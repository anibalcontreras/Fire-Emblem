using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effects;

public interface IBonusEffect
{
    void ApplyBonus(GameView view, Unit activator, Unit opponent);
}