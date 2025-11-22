using MiniCheckoutSystem.Core;
using MiniCheckoutSystem.Core.Discount;
using MiniCheckoutSystem.Core.Payment;

// Runtime polymorphism: both are IPaymentMethod,
// but behavior differs based on actual type.
IPaymentMethod card = new CreditCardPayment("**** **** **** 1234");
IPaymentMethod paypal = new PayPalPayment("me@example.com");

// Example 1: Card + no discount
var order1 = new Order(new NoDiscount(), card);
order1.AddItem("Book", 29.99m);
order1.AddItem("Headphones", 99.50m);
order1.PrintSummary();
order1.Checkout();

Console.WriteLine();
Console.WriteLine(new string('-', 40));
Console.WriteLine();

// Example 2: PayPal + 15% discount
var order2 = new Order(new PercentageDiscount(0.15m), paypal);
order2.AddItem("Online Course", 200m);
order2.PrintSummary();
order2.Checkout();

Console.WriteLine();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();