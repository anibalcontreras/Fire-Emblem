using Fire_Emblem.UnitManagment;

namespace Fire_Emblem.Weapon;

public abstract class Weapon
{
    public string Name { get; set; }
    // Método común que se utiliza en todas las subclases
    public (double WTB, string Message) CalculateAdvantage(Unit attacker, Unit defender)
    {
        double wtb = GetWTB(defender.Weapon);
        string message;

        if (wtb > 1.0)
        {
            message = $"{attacker.Name} ({Name}) tiene ventaja con respecto a {defender.Name} ({defender.Weapon.Name})";
        }
        else if (wtb < 1.0)
        {
            message = $"{defender.Name} ({defender.Weapon.Name}) tiene ventaja con respecto a {attacker.Name} ({Name})";
        }
        else
        {
            message = "Ninguna unidad tiene ventaja con respecto a la otra";
        }

        return (wtb, message);
    }

    // Método abstracto que las subclases implementarán para definir la lógica específica del triángulo de armas
    public abstract double GetWTB(Weapon opponentWeapon);

}