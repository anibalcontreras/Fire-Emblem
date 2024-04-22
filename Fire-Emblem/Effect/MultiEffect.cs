using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Effect;

public class MultiEffect : IEffect
{
    private readonly List<IEffect> _effects;

    public MultiEffect(IEnumerable<IEffect> effects)
    {
        _effects = new List<IEffect>(effects);
    }

    public void ApplyEffect(Unit unit, GameView view)
    {
        foreach (var effect in _effects)
        {
            effect.ApplyEffect(unit, view);
        }
    }

    public void RevertEffect(Unit unit, GameView view)
    {
        foreach (var effect in _effects)
        {
            effect.RevertEffect(unit, view);
        }
    }

    public IEffect Clone()
    {
        return new MultiEffect(_effects.Select(effect => effect.Clone()));
    }

    public override string ToString()
    {
        return string.Join(" + ", _effects.Select(effect => effect.ToString()));
    }
}
