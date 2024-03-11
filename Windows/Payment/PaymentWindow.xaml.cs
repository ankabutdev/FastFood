using FastFood.Components.Baskets;
using FastFood.Enums;
using FastFood.Helpers;
using FastFood.Repositories.Orders;
using FastFood.Repositories.Products;
using FastFood.ViewModels.Orders;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

#pragma warning disable

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
        PaymentType[] arr = { PaymentType.ByCard/*, PaymentType.ByCash*/ };
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
        // Registered orders for users

        var orders = await _orderRepository
            .GetAllOrderByUserIdByIsPaidFalseAsync(UserId);

        foreach (var order in orders)
        {
            await _orderRepository
                .UpdateOrderIfIsPaidFalseToTrueAsync(order.Id);
        }

        var orderView = await GetDataFromUI();

        // Transtaction service -> 
        // ... Pay orders price
        //

        if (orderView is not null)
        {
            MessageBox.Show("Successfully");
            this.Close();
        }
        else
        {
            MessageBox.Show("You have not products");
        }

    }

    private async Task<OrderViewModel> GetDataFromUI()
    {
        var orderView = new OrderViewModel();

        orderView.Description = new TextRange(rbDescription.Document.ContentStart,
            rbDescription.Document.ContentEnd).Text;

        orderView.FullName = tbFullName.Text;
        orderView.PaymentType = (PaymentType)cmbPaymentTypes.SelectedValue;
        orderView.Status = OrderStatus.InProcess;
        orderView.PhoneNumber = tbPhoneNumber.Text;
        orderView.Address = tbAddress.Text;
        orderView.CardNumber = tbCardNumber.Text;
        orderView.CVV = rbCardNumberSmallNumbers.Text;

        orderView.CreatedAt = orderView.UpdatedAt
            = TimeHelper.GetDateTime();

        return orderView;
    }
}
