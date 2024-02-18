using FastFood.Components.Products;
using FastFood.Repositories.Products;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastFood.Pages.HotDrinks;

/// <summary>
/// Interaction logic for HotDrinksPage.xaml
/// </summary>
public partial class HotDrinksPage : Page
{
    private readonly ProductRepository _productRepository;

    public HotDrinksPage()
    {
        InitializeComponent();
        this._productRepository = new ProductRepository();
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await RefreshAsync();
    }

    public async Task RefreshAsync()
    {
        wrpHotDrinks.Children.Clear();
        var products = await _productRepository.GetAllByCategoryIdAsync(2);

        foreach (var product in products)
        {
            var productViewUserControl = new ProductViewUserControl();
            productViewUserControl.SetData(product);
            wrpHotDrinks.Children.Add(productViewUserControl);
        }
    }

    private async void tbSearch_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            wrpHotDrinks.Children.Clear();

            var products = await _productRepository.SearchByCategoryIdFromProductAsync(2, tbSearch.Text);

            foreach (var product in products)
            {
                var appointmentsViewUserControl = new ProductViewUserControl();
                appointmentsViewUserControl.SetData(product);
                wrpHotDrinks.Children.Add(appointmentsViewUserControl);
            }
        }
    }
}
