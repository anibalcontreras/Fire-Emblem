using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public interface IEffect
{
    void ApplyEffect(GameView view, Unit activator, Unit opponent);
    void RevertEffect(GameView view, Unit unit, Unit rival);

    IEffect Clone();
}