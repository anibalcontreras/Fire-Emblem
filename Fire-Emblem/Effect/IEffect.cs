using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public interface IEffect
{
    void ApplyEffect(GameView view, Unit unit);
    void RevertEffect(GameView view, Unit unit);

    IEffect Clone();
}