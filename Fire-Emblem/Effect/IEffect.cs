using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public interface IEffect
{
    void ApplyEffect(Unit unit, GameView view);
    void RevertEffect(Unit unit, GameView view);

    IEffect Clone();
}