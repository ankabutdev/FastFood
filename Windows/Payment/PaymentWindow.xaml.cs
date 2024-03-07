using FastFood.Components.Baskets;
using FastFood.Entites.Orders;
using FastFood.Enums;
using FastFood.Repositories.Orders;
using FastFood.Repositories.Products;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

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
        PaymentType[] arr = { PaymentType.ByCard, PaymentType.ByCash };
        cmbPaymentTypes.ItemsSource = arr;
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

    private async void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        //var categoryType = cmbPaymentTypes.SelectedValue;

        //if ((PaymentType)categoryType is PaymentType.ByCard)
        //{
        //    brPayment.Visibility = Visibility.Visible;
        //}

        var data = await GetDataFromUI();

        //await _orderRepository.UpdateAsync(data.Id, data);

    }

    private async Task<Order> GetDataFromUI()
    {
        var order = new Order();

        order.UserId = this.UserId;
        //order.ProductId = 0;
        order.Description = new TextRange(rbDescription.Document.ContentStart,
            rbDescription.Document.ContentEnd).Text;

        order.PaymentType = (PaymentType)cmbPaymentTypes.SelectedValue;

        order.Status = OrderStatus.InProcess;
        order.IsPaid = true;

        return order;
    }

}
