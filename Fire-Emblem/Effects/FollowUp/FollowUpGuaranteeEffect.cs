using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.FollowUp;

public class FollowUpGuaranteeEffect : IEffect
{
    private EffectTarget _target;
    
    public FollowUpGuaranteeEffect(EffectTarget target)
    {
        _target = target;
    }
    
    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.SetFollowUpGuaranteed();
        targetUnit.AddActiveEffect(this);
    }
}
