// using Fire_Emblem.Stats;
// using Fire_Emblem.UnitManagment;
//
// namespace Fire_Emblem.Effect;
//
// public class FairFightEffect : IEffect
// {
//     private StatType _statToIncrease;
//     private int _amount;
//
//     public FairFightEffect(StatType statToIncrease, int amount)
//     {
//         _statToIncrease = statToIncrease;
//         _amount = amount;
//     }
//
//     public virtual void ApplyEffect(Unit unit, Unit attacker, Unit defender)
//     {
//         attacker.IncreaseStat(_statToIncrease, _amount);
//         defender.IncreaseStat(_statToIncrease, _amount);
//     }
//
//     public void RevertEffect(Unit unit, Unit attacker, Unit defender)
//     {
//         attacker.IncreaseStat(_statToIncrease, -_amount);
//         defender.IncreaseStat(_statToIncrease, -_amount);
//     }
//
//     public IEffect Clone()
//     {
//         return new FairFightEffect(_statToIncrease, _amount);
//     }
//     
//     public override string ToString()
//     {
//         return $"{_statToIncrease}+{_amount}";
//     }
// }
