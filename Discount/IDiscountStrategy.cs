namespace MiniCheckoutSystem.Discount;

// =========================
//  COMPOSITION: DISCOUNT STRATEGIES
// =========================
public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal amount);
}
