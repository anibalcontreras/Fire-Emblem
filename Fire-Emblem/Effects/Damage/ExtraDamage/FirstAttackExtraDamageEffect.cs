using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

public class FirstAttackExtraDamageEffect : IEffect
{
    private readonly int _amount;
    private EffectTarget Target { get; }
    
    public FirstAttackExtraDamageEffect(EffectTarget target)
    {
        Target = target;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        int amount = CalculateExtraDamage(activator, opponent);
        targetUnit.ApplyFirstAttackExtraDamageEffect(amount);
        targetUnit.AddActiveEffect(this);
    }

    private int CalculateExtraDamage(Unit activator, Unit opponent)
    {
        int atk = activator.FirstAttackAtk;
        int res = opponent.FirstAttackRes;
        return (int)(0.25 * (atk - res));
    }
}