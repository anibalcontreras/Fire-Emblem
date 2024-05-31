using Fire_Emblem.Combats.Units;
using Fire_Emblem.Combats.Stats;

namespace Fire_Emblem.Combats.Effects;

public interface IEffect
{
    void ApplyEffect(Unit activator, Unit opponent);
}