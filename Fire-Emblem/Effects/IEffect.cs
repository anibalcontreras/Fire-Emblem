using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public interface IEffect
{
    EffectTarget Target { get; }
    StatType StatType { get; }
    int? Amount { get; }
    void ApplyEffect(Unit activator, Unit opponent);
}