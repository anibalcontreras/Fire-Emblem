using Fire_Emblem.Units;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Effects;

public interface IPenaltyEffect : IEffect
{
    StatType StatType { get; }
    int? Amount { get; }
}