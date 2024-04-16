using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Condition;

public class BeginningOfTheCombatCondition : ICondition
{
    public bool IsConditionMet(Unit unit, Combat combat)
    {
        Console.WriteLine("Estamos con la unidad: " + unit.Name);
        Console.WriteLine("Las skills son: " + unit.Skills.Count());
        Console.WriteLine("La condicion es: " + (combat.State == CombatState.StartOfCombat));
        return combat.State == CombatState.StartOfCombat;
    }
    
    public ICondition Clone()
    {
        return new BeginningOfTheCombatCondition();
    }
}