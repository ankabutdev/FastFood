using FastFood.Components.OrdersResults;
using FastFood.Repositories.Categories;
using FastFood.Repositories.Orders;
using FastFood.Repositories.Products;
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

    //private Order Order { get; set; }
    private long UserId { get; set; }

    public OrderPage(/*Order order,*/ long userId)
    {
        InitializeComponent();
        this._orderRepository = new OrderRepository();
        this._productRepository = new ProductRepository();
        this._categoryRepository = new CategoryRepository();
        //this.Order = order;
        UserId = userId;
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
}
