using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public interface IPenaltyEffect : IEffect
{
    StatType StatType { get; }
    int? Amount { get; }
}