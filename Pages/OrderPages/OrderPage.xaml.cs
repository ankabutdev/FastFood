using FastFood.Components.OrdersResults;
using FastFood.Repositories.Categories;
using FastFood.Repositories.Orders;
using FastFood.Repositories.Products;
using FastFood.Windows.Payment;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FastFood.Pages.OrderPages;

/// <summary>
/// Interaction logic for OrderPage.xaml
/// </summary>
public partial class OrderPage : Page
{
    private readonly OrderRepository _orderRepository;
    private readonly ProductRepository _productRepository;
    private readonly CategoryRepository _categoryRepository;

    private long UserId { get; set; }

    public OrderPage(long userId)
    {
        InitializeComponent();
        this._orderRepository = new OrderRepository();
        this._productRepository = new ProductRepository();
        this._categoryRepository = new CategoryRepository();
        UserId = userId;
        //SubscribeToOrderChangedEvents();
    }

    private void SubscribeToOrderChangedEvents()
    {
        foreach (OrderResultUserControl control in wrpOrder.Children)
        {
            control.OrderChanged += OrderResultUserControl_OrderChanged!;
        }
    }

    // Event handler for OrderChanged event in OrderResultUserControl
    private async void OrderResultUserControl_OrderChanged(object sender, EventArgs e)
    {
        // Refresh the OrderPage when the order changes
        await RefreshAsync();
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await RefreshAsync();
    }

    public async Task RefreshAsync()
    {
        wrpOrder.Children.Clear();

        var orders = await _orderRepository
            .GetAllOrderByUserIdByIsPaidFalseAsync(UserId);

        foreach (var order in orders)
        {
            var orderResultUserControl = new OrderResultUserControl();
            orderResultUserControl.SetData(order);
            wrpOrder.Children.Add(orderResultUserControl);
        }
    }

    private async void PayForOrders_Click(object sender, RoutedEventArgs e)
    {
        var result = await _orderRepository
            .GetAllOrderByUserIdByIsPaidFalseAsync(UserId);

        PaymentWindow paymentWindow = new PaymentWindow();
        paymentWindow.ShowDialog();
        
    }
}
