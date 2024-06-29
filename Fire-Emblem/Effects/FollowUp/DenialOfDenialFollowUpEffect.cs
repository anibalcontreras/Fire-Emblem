using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.FollowUp;

public class DenialOfDenialFollowUpEffect : IEffect
{
    private EffectTarget _target;

    public DenialOfDenialFollowUpEffect(EffectTarget target)
    {
        _target = target;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        targetUnit.SetDenialOfDenialFollowUp();
        EffectsList targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}