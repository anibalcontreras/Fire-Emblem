// using Fire_Emblem;
// using Fire_Emblem.Effects;
// using Fire_Emblem.Stats;
// using Fire_Emblem.Units;
//
// public class MutualBonusEffect : IEffect, IBonusEffect
// {
//     private readonly StatType _stat;
//     private readonly int _amount;
//
//     public MutualBonusEffect(StatType stat, int amount)
//     {
//         _stat = stat;
//         _amount = amount;
//     }
//
//     public void ApplyEffect(GameView view, Unit activator, Unit opponent)
//     {
//         ApplyBonus(view, activator, opponent);
//     }
//
//     public void ApplyBonus(GameView view, Unit activator, Unit opponent)
//     {
//         activator.ApplyStatBonusAndPenaltyEffect(_stat, _amount);
//         opponent.ApplyStatBonusAndPenaltyEffect(_stat, _amount);
//         view.AnnounceBonusStat(activator.Name, $"{_stat}+{_amount}");
//         view.AnnounceBonusStat(opponent.Name, $"{_stat}+{_amount}");
//     }
// }