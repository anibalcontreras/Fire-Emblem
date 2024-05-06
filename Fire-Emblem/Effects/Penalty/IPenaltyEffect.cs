using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public interface IPenaltyEffect
{
    StatType StatType { get; }
    int? Amount { get; }
    EffectTarget Target { get; }
    void ApplyEffect(Unit activator, Unit opponent);
}