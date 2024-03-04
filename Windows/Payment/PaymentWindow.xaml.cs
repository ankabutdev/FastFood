using FastFood.Components.Baskets;
using FastFood.Repositories.Orders;
using FastFood.Repositories.Products;
using System.Threading.Tasks;
using System.Windows;

namespace FastFood.Windows.Payment;

/// <summary>
/// Interaction logic for PaymentWindow.xaml
/// </summary>
public partial class PaymentWindow : Window
{
    private readonly long UserId;
    private readonly OrderRepository _orderRepository;
    private readonly ProductRepository _productRepository;
    private readonly OrderDetailsRepository _orderDetailsRepository;

    public PaymentWindow(long userId)
    {
        InitializeComponent();
        this.UserId = userId;
        this._orderRepository = new OrderRepository();
        this._productRepository = new ProductRepository();
        this._orderDetailsRepository = new OrderDetailsRepository();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await RefreshAsync();
    }

    public async Task RefreshAsync()
    {
        wrpBasket.Children.Clear();

        var orders = await _orderRepository
            .GetAllOrderByUserIdByIsPaidFalseAsync(UserId);

        foreach (var order in orders)
        {
            var basketViewUserControl = new BasketUserControl();
            basketViewUserControl.SetData(order);
            wrpBasket.Children.Add(basketViewUserControl);
        }
    }
}
