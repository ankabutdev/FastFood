using FastFood.Components.Products;
using FastFood.Repositories.Products;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastFood.Pages.Foods;

/// <summary>
/// Interaction logic for FoodPage.xaml
/// </summary>
public partial class FoodPage : Page
{
    private readonly ProductRepository _productRepository;
    public long UserId { get; set; }

    public FoodPage(long userId)
    {
        InitializeComponent();
        this._productRepository = new ProductRepository();
        UserId = userId;
    }

    private async void tbSearch_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            wrpFood.Children.Clear();

            var products = await _productRepository.SearchByCategoryIdFromProductAsync(4, tbSearch.Text);

            foreach (var product in products)
            {
                var appointmentsViewUserControl = new ProductViewUserControl(UserId);
                appointmentsViewUserControl.SetData(product);
                wrpFood.Children.Add(appointmentsViewUserControl);
            }
        }
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await RefreshAsync();
    }

    public async Task RefreshAsync()
    {
        wrpFood.Children.Clear();
        var products = await _productRepository.GetAllByCategoryIdAsync(4);

        foreach (var product in products)
        {
            var productViewUserControl = new ProductViewUserControl(UserId);
            productViewUserControl.SetData(product);
            wrpFood.Children.Add(productViewUserControl);
        }
    }
}
