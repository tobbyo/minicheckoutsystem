using FluentAssertions;
using MiniCheckoutSystem.Core.Discount;

namespace MiniCheckoutSystem.Core.Tests;

public class DiscountStrategyTests
{
    [Fact]
    public void NoDiscount_ShouldReturnSameAmount()
    {
        // Arrange
        var strategy = new NoDiscount();

        // Act
        var result = strategy.ApplyDiscount(100m);

        // Assert
        result.Should().Be(100m);
    }

    [Fact]
    public void PercentageDiscount_ShouldApplyPercentageCorrectly()
    {
        // Arrange
        var strategy = new PercentageDiscount(20m); // 20%

        // Act
        var result = strategy.ApplyDiscount(200m);

        // Assert
        result.Should().Be(160m); // 20% off
    }
}
