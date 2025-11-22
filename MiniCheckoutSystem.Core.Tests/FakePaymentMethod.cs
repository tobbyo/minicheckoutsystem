using MiniCheckoutSystem.Core.Payment;

namespace MiniCheckoutSystem.Core.Tests;

//Mock the pay method class
public class FakePaymentMethod : PaymentMethodBase
{
    public decimal LastPaidAmount { get; private set; }

    public FakePaymentMethod() : base("FakePayment")
    {
    }

    public override void Pay(decimal amount)
    {
        LastPaidAmount = amount;
    }
}
