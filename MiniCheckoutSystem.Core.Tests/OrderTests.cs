using FluentAssertions;
using MiniCheckoutSystem.Core.Discount;
using MiniCheckoutSystem.Core.Payment;
using MiniCheckoutSystem.Core;
using Moq;

namespace MiniCheckoutSystem.Core.Tests;

public class OrderTests
{
    [Fact]
    public void AddItem_ShouldIncreaseTotal_AndTrackItems()
    {
        // Arrange
        var discountStrategyMock = new Mock<IDiscountStrategy>();
        discountStrategyMock
            .Setup(d => d.ApplyDiscount(It.IsAny<decimal>()))
            .Returns<decimal>(x => x);

        var paymentMethodMock = new Mock<IPaymentMethod>();

        var order = new Order(discountStrategyMock.Object, paymentMethodMock.Object);
        
        // Act
        order.AddItem("Book", 20m);
        order.AddItem("Headphones", 80m);

        
        // Assert
        Action act = () => order.Checkout();

        act.Should().NotThrow();
        paymentMethodMock.Verify(p => p.Pay(100m), Times.Once);
    }

    [Fact]
    public void AddItem_ShouldThrow_WhenPriceIsNonPositive()
    {
        // Arrange
        var discountStrategyMock = new Mock<IDiscountStrategy>();
        discountStrategyMock.Setup(d => d.ApplyDiscount(It.IsAny<decimal>()))
                            .Returns<decimal>(x => x);

        var paymentMethodMock = new Mock<IPaymentMethod>();

        var order = new Order(discountStrategyMock.Object, paymentMethodMock.Object);

        // Act
        Action act = () => order.AddItem("Invalid", 0m);

        // Assert
        act.Should().Throw<ArgumentException>()
           .WithParameterName("price");
    }
}
