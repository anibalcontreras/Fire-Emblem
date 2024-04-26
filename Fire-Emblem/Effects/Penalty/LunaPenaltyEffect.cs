// using Fire_Emblem.Effect;
// using Fire_Emblem.Stats;
// using Fire_Emblem.UnitManagment;
//
// namespace Fire_Emblem.Effects;
//
// public class LunaPenaltyEffect : IEffect
// {
//     public void ApplyEffect(GameView view, Unit activator, Unit opponent)
//     {
//         // Calcula la penalización como la mitad de los stats de Def y Res base del oponente.
//         int halfDefPenalty = opponent.BaseDef / 2;
//         int halfResPenalty = opponent.BaseRes / 2;
//
//         // Aplica la penalización a Def y Res.
//         opponent.IncreaseStat(StatType.Def, -halfDefPenalty);
//         opponent.IncreaseStat(StatType.Res, -halfResPenalty);
//
//         // Anuncia la penalización en la vista del juego.
//         view.AnnouncePenaltyStat(opponent.Name, $"Def-{halfDefPenalty}, Res-{halfResPenalty}");
//     }
//
//     public void RevertEffect(GameView view, Unit activator, Unit opponent)
//     {
//         // Revierte la penalización aplicada (esto es útil si necesitas revertir efectos temporalmente durante el juego).
//         int halfDefPenalty = opponent.BaseDef / 2;
//         int halfResPenalty = opponent.BaseRes / 2;
//
//         opponent.IncreaseStat(StatType.Def, halfDefPenalty);
//         opponent.IncreaseStat(StatType.Res, halfResPenalty);
//     }
//
//     public IEffect Clone()
//     {
//         // Devuelve una nueva instancia de este efecto para ser usado por otros sistemas de efectos o habilidades.
//         return new LunaPenaltyEffect();
//     }
//
//     public override string ToString()
//     {
//         // Representación en cadena de este efecto, útil para la depuración y registros.
//         return "Luna Penalty Effect";
//     }
// }