using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public interface IBonusEffect : IEffect
{
    StatType StatType { get; }
    int? Amount { get; }
}
