using Fire_Emblem.Effects.FollowUp;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Stats;

namespace Fire_Emblem.Effects;

public class EffectsList
{
    private readonly List<IEffect> _effects = new();
    
    public IEnumerable<IEffect> Items => _effects.AsReadOnly();
    
    public void AddEffect(IEffect effect)
        => _effects.Add(effect);
    
    public void ClearEffects() => _effects.Clear();
    
    public bool HasActiveNeutralizationBonus(StatType statType)
    {
        return _effects.Any(effect => effect is NeutralizationBonusEffect bonus && bonus.StatType == statType);
    }
    
    public bool HasActiveNeutralizationPenalty(StatType statType)
    {
        return _effects.Any(effect => effect is NeutralizationPenaltyEffect penalty && penalty.StatType == statType);
    }
}