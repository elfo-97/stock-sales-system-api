namespace StockSalesSystem.Domain.Orders;
public class OrderItem
{
    public Guid Id { get; private set; } = default!;
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public decimal TotalPrice => Price * Quantity;

    public OrderItem(string name, int quantity, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
        if (price < 0)
            throw new ArgumentException("Price cannot be negative.", nameof(price));
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Quantity = quantity;
    }
    protected OrderItem() { }
}
