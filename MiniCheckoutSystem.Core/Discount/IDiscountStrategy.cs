namespace MiniCheckoutSystem.Core.Discount;

// =========================
//  COMPOSITION: DISCOUNT STRATEGIES
// =========================
public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal amount);
}
