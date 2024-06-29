using Fire_Emblem.Stats;
using Fire_Emblem.Units;

namespace Fire_Emblem.Effects.Damage.ExtraDamage;

public class ExtraDamagePerStatDifferenceEffect : IExtraDamageEffect
{
    private readonly double _percentage = 0.70;
    private readonly int _minExtraDamage = 0;
    private readonly int _maxExtraDamage = 7;
    private readonly StatType _statType;
    private EffectTarget _target;

    public ExtraDamagePerStatDifferenceEffect(StatType statType, EffectTarget effectTarget)
    {
        _statType = statType;
        _target = effectTarget;
    }

    public void ApplyEffect(Unit activator, Unit opponent)
    {
        
        Unit targetUnit = _target == EffectTarget.Unit ? activator : opponent;
        int activatorStatValue = targetUnit.GetCurrentStat(_statType);
        int opponentStatValue = opponent.GetCurrentStat(_statType);
        int statDifference = activatorStatValue - opponentStatValue;

        int extraDamage = (int)(statDifference * _percentage);
        extraDamage = Math.Clamp(extraDamage, _minExtraDamage, _maxExtraDamage);

        if (extraDamage > 0)
        {
            targetUnit.ApplyExtraDamageEffect(extraDamage);
        }

        EffectsList targetUnitEffects = targetUnit.Effects;
        targetUnitEffects.AddEffect(this);
    }
}