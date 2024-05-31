using Fire_Emblem.Combats.Stats;
using Fire_Emblem.Combats.Units;

namespace Fire_Emblem.Combats.Effects;

public interface IBonusEffect : IEffect
{
    StatType StatType { get; }
    int? Amount { get; }
}
