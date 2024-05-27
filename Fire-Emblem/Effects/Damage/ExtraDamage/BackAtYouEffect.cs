using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

public class BackAtYouEffect : IExtraDamageEffect
{
    private EffectTarget Target { get; }
        
    public BackAtYouEffect(EffectTarget target)
    {
        Target = target;
    }
        
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = Target == EffectTarget.Unit ? activator : opponent;
        int extraDamage = (activator.BaseHp - activator.CurrentHP) / 2;
        targetUnit.ApplyExtraDamageEffect(extraDamage);
        targetUnit.AddActiveEffect(this);
    }
}