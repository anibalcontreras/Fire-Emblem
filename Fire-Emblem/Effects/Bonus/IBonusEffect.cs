using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public interface IBonusEffect
{
    void ApplyBonus(GameView view, Unit activator, Unit opponent);
}