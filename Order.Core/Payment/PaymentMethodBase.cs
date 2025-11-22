namespace MiniCheckoutSystem.Payment;

public abstract class PaymentMethodBase : IPaymentMethod
{
    //Encapsulation
    private readonly string _name;
    public PaymentMethodBase(string name)
    {
        _name = name;
    }

    public string Name => _name;

    // Run-time polymorphism (Late binding): virtual method
    public abstract void Pay(decimal amount);

    //Compile-time polymorphism (Early binding): method overloading
    // PrintReceipt is overloaded, two versions
    public void PrintReceipt(decimal amount)
    {
        Console.WriteLine($"[{Name}] Payment of {amount:C} processed.");
    }

    public void PrintReceipt(decimal amount, string reference)
    {
        Console.WriteLine($"[{Name}] Payment of {amount:C} processed. Ref: {reference}");
    }
}
