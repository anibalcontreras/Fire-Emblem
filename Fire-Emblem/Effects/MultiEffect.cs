using System.Collections;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class MultiEffect : IEnumerable<IEffect>
{
    private readonly List<IEffect> _effects;
    
    public MultiEffect(IEnumerable<IEffect> effects)
    {
        _effects = new List<IEffect>(effects);
    }
    
    public IEnumerator<IEffect> GetEnumerator()
    {
        return _effects.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    // public void ApplyEffect(Unit activator, Unit opponent)
    // {
    //     foreach (IEffect effect in _effects)
    //     {
    //         effect.ApplyEffect(activator, opponent);
    //     }
    // }
}
