// =========================
//  ENCAPSULATION + COMPOSITION: ORDER
// =========================
using MiniCheckoutSystem.Core.Discount;
using MiniCheckoutSystem.Core.Payment;

namespace MiniCheckoutSystem.Core;

public class Order
{
    private readonly List<string> _items = new();
    private decimal _total;

    // Composition: Order "has-a" Discount
    // Composition: Order "has-a" PaymentMethod

    private readonly IDiscountStrategy _discountStrategy;
    private readonly IPaymentMethod _paymentMethod;
    public Order(IDiscountStrategy discountStrategy, IPaymentMethod paymentMethod)
    {
        _discountStrategy = discountStrategy ?? throw new ArgumentNullException(nameof(discountStrategy));
        _paymentMethod = paymentMethod ?? throw new ArgumentNullException(nameof(paymentMethod));
    }

    public void AddItem(string itemName, decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Price must be positive.", nameof(price));

        _items.Add(itemName);
        _total += price;
    }

    public void PrintSummary()
    {
        Console.WriteLine("=== Order Summary ===");
        foreach (var item in _items)
        {
            Console.WriteLine($" - {item}");
        }
        Console.WriteLine($"Subtotal: {_total:C}");

        var discounted = _discountStrategy.ApplyDiscount(_total);
        Console.WriteLine($"After Discount: {discounted:C}");
        Console.WriteLine($"Payment Method: {_paymentMethod.Name}");
    }

    public void Checkout()
    {
        var finalAmount = _discountStrategy.ApplyDiscount(_total);

        Console.WriteLine();
        Console.WriteLine("Processing payment...");
        _paymentMethod.Pay(finalAmount);

        // If we know we have a PaymentMethodBase, we can also demo overloads
        if (_paymentMethod is PaymentMethodBase baseMethod)
        {
            // Compile-time polymorphism: two overloads
            baseMethod.PrintReceipt(finalAmount);
            baseMethod.PrintReceipt(finalAmount, reference: Guid.NewGuid().ToString("N")[..8]);
        }
    }

}
