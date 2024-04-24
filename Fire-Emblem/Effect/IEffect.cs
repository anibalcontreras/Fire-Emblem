using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public interface IEffect
{
    void ApplyEffect(GameView view, Unit activator, Unit opponent);
    IEffect Clone();
}