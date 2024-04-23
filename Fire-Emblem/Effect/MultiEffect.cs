using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public class MultiEffect : IEffect
{
    private readonly List<IEffect> _effects;

    public MultiEffect(IEnumerable<IEffect> effects)
    {
        _effects = new List<IEffect>(effects);
    }

    public void ApplyEffect(GameView view, Unit activator, Unit opponent)
    {
        foreach (var effect in _effects)
        {
            effect.ApplyEffect(view, activator, opponent);
        }
    }

    public void RevertEffect(GameView view, Unit unit, Unit rival)
    {
        foreach (var effect in _effects)
        {
            effect.RevertEffect(view, unit, rival);
        }
    }

    public IEffect Clone()
    {
        return new MultiEffect(_effects.Select(effect => effect.Clone()));
    }
}
