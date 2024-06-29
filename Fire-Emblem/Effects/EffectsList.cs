namespace Fire_Emblem.Effects;

public class EffectsList
{
    private readonly List<IEffect> _effects = new();
    
    public IEnumerable<IEffect> Items => _effects.AsReadOnly();
    
    public void AddEffect(IEffect effect)
        => _effects.Add(effect);
    
    public void ClearEffects()
        => _effects.Clear();
}