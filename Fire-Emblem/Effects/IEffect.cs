using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public interface IEffect
{
    void ApplyEffect(Unit activator, Unit opponent);
}