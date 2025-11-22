namespace MiniCheckoutSystem.Core.Payment;

public class PayPalPayment : PaymentMethodBase
{
    // Encapsulated
    private readonly string _email;

    public PayPalPayment(string email) : base("Paypal")
    {
        _email = email;
    }

    public override void Pay(decimal amount)
    {
        // Simulate call paypal API
        Console.WriteLine($" -> Sending PayPal charge of {amount:C} to {_email}.");
    }
}
