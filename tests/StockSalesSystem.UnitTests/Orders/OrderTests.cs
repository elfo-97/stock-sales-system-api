using StockSalesSystem.Domain.Orders;
using StockSalesSystem.Domain.Exceptions;

namespace StockSalesSystem.UnitTests.Orders;
public class OrderTests
{
    [Fact]
    public void CloseOrder_WithItems_ShouldChangeStatusToClosed()
    {
        var order = new Order();
        var item = new OrderItem("Test Item", 1, 10m);
        order.AddItem(item);

        order.CloseOrder();

        Assert.Equal(OrderStatus.Closed, order.Status);
    }
    [Fact]
    public void CloseOrder_WithoutItems_ShouldThrowDomainException()
    {
        var order = new Order();

        var exception = Assert.Throws<DomainException>(() => order.CloseOrder());

        Assert.Equal("Cannot close an order without items.", exception.Message);
    }
    [Fact]
    public void AddItem_WhenOrderIsClosed_ShouldThrowDomainException()
    {
        var order = new Order();
        var item = new OrderItem("Test Item", 1, 10m);
        order.AddItem(item);
        order.CloseOrder();

        var newItem = new OrderItem("New Item", 1, 5m);
        var exception = Assert.Throws<DomainException>(() => order.AddItem(newItem));

        Assert.Equal("Cannot add items to a closed or cancelled order.", exception.Message);
    }
    [Fact]
    public void RemoveItem_WhenOrderIsClosed_ShouldThrowDomainException()
    {
        var order = new Order();
        var item = new OrderItem("Test Item", 1, 10m);
        order.AddItem(item);
        order.CloseOrder();

        var exception = Assert.Throws<DomainException>(() => order.RemoveItem(item.Id));

        Assert.Equal("Cannot remove items from a closed or cancelled order.", exception.Message);
    }
}