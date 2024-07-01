namespace Fire_Emblem.Exception;

public class MethodIsOverwrittenException : ApplicationException
{
    private static readonly string _defaultMessage = "El método ha sido sobrescrito en una clase derivada. " +
                                                     "Este error se lanza porque C# obliga a implementar " +
                                                     "todos los métodos abstractos en una clase derivada.";

    public MethodIsOverwrittenException() : base(_defaultMessage) {}
}
