using Fire_Emblem.Units;

namespace Fire_Emblem.Effects;

public class MultiEffect : IEffect
{
    private readonly List<IEffect> _effects;

    public MultiEffect(IEnumerable<IEffect> effects)
    {
        _effects = new List<IEffect>(effects);
    }

    public void ApplyEffect(GameView view, Unit activator, Unit opponent)
    {
        foreach (IEffect effect in _effects)
        {
            effect.ApplyEffect(view, activator, opponent);
        }
    }
}
