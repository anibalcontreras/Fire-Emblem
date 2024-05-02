using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralization;
using Fire_Emblem.Units;

namespace Fire_Emblem.Skills;

public class Skill
{
    public string Name { get; set; }
    public MultiEffect Effect { get; set; }
    public MultiCondition Condition { get; set; }
    public Skill(string name, MultiCondition condition, MultiEffect effect)
    {
        Name = name;
        Condition = condition;
        Effect = effect;
    }
    
    public void ActivateEffects(GameView view, Unit unit, Unit rival)
    {
        // Filtra y aplica los efectos de Bonus
        foreach (IEffect effect in Effect.Where(e => e is BonusEffect))
        {
            effect.ApplyEffect(unit, rival);
        }

        // Filtra y aplica los efectos de Penalty
        foreach (IEffect effect in Effect.Where(e => e is PenaltyEffect))
        {
            effect.ApplyEffect(unit, rival);
        }

        // Filtra y aplica los efectos de Neutralización de Bonos
        foreach (IEffect effect in Effect.Where(e => e is NeutralizationBonusEffect))
        {
            effect.ApplyEffect(unit, rival);
        }
    }
}