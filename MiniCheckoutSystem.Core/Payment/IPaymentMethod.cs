namespace MiniCheckoutSystem.Core.Payment;

public interface IPaymentMethod
{
    string Name { get; }
    void Pay(decimal amount);
}
