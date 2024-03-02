using FastFood.Components.Products;
using FastFood.Repositories.Products;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastFood.Pages.AlItems;

/// <summary>
/// Interaction logic for AllItemsPage.xaml
/// </summary>
public partial class AllItemsPage : Page
{
    private readonly ProductRepository _productRepository;
    public long UserId { get; set; }

    public AllItemsPage(long UserId)
    {
        InitializeComponent();
        this._productRepository = new ProductRepository();
        this.UserId = UserId;
    }

    private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        await RefreshAsync();
    }

    public async Task RefreshAsync()
    {
        wrpAllItems.Children.Clear();
        var products = await _productRepository.GetAllAsync();

        foreach (var product in products)
        {
            var productViewUserControl = new ProductViewUserControl(UserId);
            productViewUserControl.SetData(product);
            wrpAllItems.Children.Add(productViewUserControl);
        }
    }

    private async void tbSearch_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            wrpAllItems.Children.Clear();

            var products = await _productRepository.SearchAsync(tbSearch.Text);

            foreach (var product in products)
            {
                var appointmentsViewUserControl = new ProductViewUserControl(UserId);
                appointmentsViewUserControl.SetData(product);
                wrpAllItems.Children.Add(appointmentsViewUserControl);
            }
        }
    }
}
