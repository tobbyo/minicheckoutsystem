using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniCheckoutSystem.Core.Tests;


public class PaymentMethodBaseTests
{
    [Fact]
    public void Pay_ShouldBeOverridable_AndTrackAmount()
    {
        // Arrange
        var payment = new FakePaymentMethod();

        // Act
        payment.Pay(123.45m);

        // Assert
        payment.LastPaidAmount.Should().Be(123.45m);
        payment.Name.Should().Be("FakePayment");
    }

    [Fact]
    public void PrintReceipt_Overloads_ShouldWriteExpectedOutput()
    {
        // Arrange
        var payment = new FakePaymentMethod();
        var writer = new StringWriter();
        var originalOut = Console.Out;

        try
        {
            Console.SetOut(writer);

            // Act
            payment.PrintReceipt(50m);
            payment.PrintReceipt(75m, "REF123");

            // Assert
            var output = writer.ToString();
            output.Should().Contain("Payment of $50.00 processed.");
            output.Should().Contain("Payment of $75.00 processed. Ref: REF123");
        }
        finally
        {
            Console.SetOut(originalOut);
        }

    }
}
