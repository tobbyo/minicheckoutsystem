namespace MiniCheckoutSystem.Payment;

public interface IPaymentMethod
{
    string Name { get; }
    void Pay(decimal amount);
}
