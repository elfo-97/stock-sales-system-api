namespace StockSalesSystem.Domain.Orders;
public class Order
{
    private readonly List<OrderItem> _items = new();

    public Guid Id { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    public DateTime CreatedAt { get; private set; }

    public decimal TotalPrice => Items.Sum(item => item.TotalPrice);


    protected Order() { 
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    public void AddItem(OrderItem item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        if (Status != OrderStatus.Pending)
        {
            throw new Exceptions.DomainException("Cannot add items to a closed or cancelled order.");
        }

        _items.Add(item);
    }

    public void RemoveItem(Guid itemId)
    {
        if (Status != OrderStatus.Pending)
        {
            throw new Exceptions.DomainException("Cannot remove items from a closed or cancelled order.");
        }

        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item == null)
        {
            throw new Exceptions.DomainException($"Item with id {itemId} not found in order.");
        }

        _items.Remove(item);
    }

    public void CloseOrder()
    {
        if (Status != OrderStatus.Pending)
        {
            throw new Exceptions.DomainException("Only pending orders can be closed.");
        }

        if (!_items.Any())
        {
            throw new Exceptions.DomainException("Cannot close an order without items.");
        }

        Status = OrderStatus.Closed;
    }

    public void CancelOrder()
    {
        if (Status != OrderStatus.Pending)
        {
            throw new Exceptions.DomainException("Only pending orders can be cancelled.");
        }

        Status = OrderStatus.Cancelled;
    }
}