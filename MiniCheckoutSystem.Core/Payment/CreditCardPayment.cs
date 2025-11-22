namespace MiniCheckoutSystem.Core.Payment;

public class CreditCardPayment : PaymentMethodBase
{
    // Encapsulated
    private readonly string _maskedCardNumber;

    public CreditCardPayment(string maskedCardNumber): base("Credit Card")
    {
        _maskedCardNumber = maskedCardNumber;
    }

    public override void Pay(decimal amount)
    {
        // Simulate credit card payment processing
        // Simulate call payment gateway API
        Console.WriteLine($" -> Charging {amount:C} to card {_maskedCardNumber}.");
    }
}
