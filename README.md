# MiniCheckoutSystem (OOP Concepts)

A small C# console application demonstrating core Object-Oriented Programming principles using a simple order-and-payment workflow.  
This example illustrates **encapsulation**, **abstraction**, **inheritance**, **composition**, and both **compile-time** and **run-time polymorphism** in a clean, practical structure.

---

## What This Project Demonstrates

### 1. Encapsulation
- Private fields and controlled access (`Order`, `PaymentMethodBase`, `CreditCardPayment`).

### 2. Abstraction
- Interfaces (`IPaymentMethod`, `IDiscountStrategy`).
- Abstract class (`PaymentMethodBase`).

### 3. Inheritance
- Payment implementations that share base behavior:  
  - `CreditCardPayment : PaymentMethodBase`  
  - `PayPalPayment : PaymentMethodBase`

### 4. Composition (preferred over inheritance)
- `Order` has a discount strategy.
- `Order` has a payment method.
- Behaviors are injected, not hard-coded.

### 5. Compile-time Polymorphism
- Method overloading (`PrintReceipt` overloads in `PaymentMethodBase`).

### 6. Run-time Polymorphism
- Method overriding (`Pay` in each payment type).
- Calling `Pay()` through `IPaymentMethod` demonstrates dynamic dispatch.

---


