using FastFood.Components.Products;
using FastFood.Repositories.Products;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastFood.Pages.ColdDrinks;

/// <summary>
/// Interaction logic for ColdDrinksPage.xaml
/// </summary>
public partial class ColdDrinksPage : Page
{
    private readonly ProductRepository _productRepository;

    public ColdDrinksPage()
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
        wrpColdDrinks.Children.Clear();
        var products = await _productRepository.GetAllByCategoryIdAsync(6);

        foreach (var product in products)
        {
            var productViewUserControl = new ProductViewUserControl();
            productViewUserControl.SetData(product);
            wrpColdDrinks.Children.Add(productViewUserControl);
        }
    }

    private async void tbSearch_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            wrpColdDrinks.Children.Clear();

            var products = await _productRepository.SearchByCategoryIdFromProductAsync(6, tbSearch.Text);

            foreach (var product in products)
            {
                var appointmentsViewUserControl = new ProductViewUserControl();
                appointmentsViewUserControl.SetData(product);
                wrpColdDrinks.Children.Add(appointmentsViewUserControl);
            }
        }
    }
}