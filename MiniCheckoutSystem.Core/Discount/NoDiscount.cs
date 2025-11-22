namespace MiniCheckoutSystem.Core.Discount;

public class NoDiscount : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal totalAmount) => totalAmount;

}
