namespace MiniCheckoutSystem.Discount;

public class PercentageDiscount : IDiscountStrategy
{ private readonly decimal _percentage;
    public PercentageDiscount(decimal percentage)
    {
        if (percentage < 0 || percentage > 100)
            throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage must be between 0 and 100.");
        _percentage = percentage;
    }
    public decimal ApplyDiscount(decimal totalAmount)
    {
        var discountAmount = totalAmount * (_percentage / 100);
        return totalAmount - discountAmount;
    }
}
