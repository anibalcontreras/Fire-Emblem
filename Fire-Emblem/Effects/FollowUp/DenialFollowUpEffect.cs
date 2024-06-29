using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.FollowUp;

public class DenialFollowUpEffect : IEffect
{
    private EffectTarget _target;
    
    public DenialFollowUpEffect(EffectTarget target)
    {
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.SetDenialFollowUp();
        EffectsList targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}