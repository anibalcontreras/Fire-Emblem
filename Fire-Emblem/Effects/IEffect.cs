using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public interface IEffect
{
    void ApplyEffect(GameView view, Unit activator, Unit opponent);
}