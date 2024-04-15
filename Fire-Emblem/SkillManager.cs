// using Fire_Emblem.Effect;
// using Fire_Emblem.SkillManagment;
// using Fire_Emblem.UnitManagment;
//
// namespace Fire_Emblem;
//
// public class SkillManager
// {
//     private Dictionary<Unit, List<Skill>> _unitSkills = new Dictionary<Unit, List<Skill>>();
//     private ConditionManager _conditionManager;
//
//     public SkillManager()
//     {
//         _conditionManager = new ConditionManager();
//     }
//
//     public void EquipSkill(Unit unit, Skill skill)
//     {
//         if (!_unitSkills.ContainsKey(unit))
//         {
//             _unitSkills[unit] = new List<Skill>();
//         }
//         _unitSkills[unit].Add(skill);
//     }
//
//     public void ActivateSkills(Unit unit, GameView view)
//     {
//         if (_unitSkills.ContainsKey(unit))
//         {
//             foreach (var skill in _unitSkills[unit])
//             {
//                 if (_conditionManager.AreConditionsMet(skill.Conditions, unit))
//                 {
//                     foreach (var effect in skill.Effects)
//                     {
//                         effect.ApplyEffect(unit, view);
//                     }
//                 }
//             }
//         }
//     }
//
//     public void DeactivateSkillsAfterCombat(Unit unit, GameView view)
//     {
//         if (_unitSkills.ContainsKey(unit))
//         {
//             foreach (var skill in _unitSkills[unit])
//             {
//                 foreach (var effect in skill.Effects)
//                 {
//                     if (effect is BonusEffect bonusEffect)
//                     {
//                         bonusEffect.RevertEffect(unit, view);
//                     }
//                 }
//             }
//         }
//     }
// }