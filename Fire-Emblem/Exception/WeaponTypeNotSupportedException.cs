namespace Fire_Emblem.Exception;

public class WeaponTypeNotSupportedException : ApplicationException
{
    private static readonly string DefaultMessage = "Weapon type not supported.";
    
    public WeaponTypeNotSupportedException() : base(DefaultMessage) {}
}
