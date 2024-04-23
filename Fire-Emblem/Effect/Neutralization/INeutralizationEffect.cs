using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect.Neutralization;

public interface INeutralizationEffect
{
    void MarkNeutralization(GameView view, Unit activator, Unit opponent);
    void RevertNeutralization(GameView view, Unit activator, Unit opponent);
}