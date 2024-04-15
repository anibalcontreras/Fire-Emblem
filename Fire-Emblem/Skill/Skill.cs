using Fire_Emblem.Condition;
using Fire_Emblem.Effect;
using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.SkillManagment;

public class Skill
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<IEffect> Effects { get; private set; } = new List<IEffect>();
    public List<ICondition> Conditions { get; private set; } = new List<ICondition>();
    
    public Skill(string name, string description)
    {
        Name = name;
        Description = description;
    }
    
    public void AddEffect(IEffect effect)
    {
        Effects.Add(effect);
    }

    public void AddCondition(ICondition condition)
    {
        Conditions.Add(condition);
    }
    
    // Método para activar efectos si se cumplen las condiciones.
    public void ActivateEffects(Unit unit, GameView view)
    {
        if (Conditions.All(condition => condition.IsConditionMet(unit)))
        {
            foreach (var effect in Effects)
            {
                effect.ApplyEffect(unit, view);
            }
        }
    }

    // Método para revertir efectos si es necesario.
    public void DeactivateEffects(Unit unit, GameView view)
    {
        if (Conditions.All(condition => condition.IsConditionMet(unit)))
        {
            foreach (var effect in Effects)
            {
                effect.RevertEffect(unit, view);
            }
        }
    }
}