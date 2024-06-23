using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.FollowUp;

public class DenialFollowUpGuaranteeEffect : IEffect
{
    private EffectTarget _target;

    public DenialFollowUpGuaranteeEffect(EffectTarget target)
    {
        _target = target;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.SetDenialFollowUpGuaranteed();
        targetUnit.AddActiveEffect(this);
    }
}