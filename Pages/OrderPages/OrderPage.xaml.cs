using FastFood.Components.OrdersResults;
using FastFood.Entites.Products;
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

    private Product? Product { get; set; }

    public OrderPage(Product? product)
    {
        InitializeComponent();
        this._orderRepository = new OrderRepository();
        this._productRepository = new ProductRepository();
        this._categoryRepository = new CategoryRepository();
        if (product != null)
        {
            this.Product = product;
        }
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await RefreshAsync();
    }

    public async Task RefreshAsync()
    {
        if (this.Product != null)
        {
            var orderResultUserControl = new OrderResultUserControl();
            orderResultUserControl.SetData(Product);

            wrpOrder.Children.Add(orderResultUserControl);
        }
    }
}
