using FastFood.Components.Products;
using FastFood.Repositories.Products;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastFood.Pages.Disserts;

/// <summary>
/// Interaction logic for DissertsPage.xaml
/// </summary>
public partial class DissertsPage : Page
{
    private readonly ProductRepository _productRepository;
    public long UserId { get; set; }

    public DissertsPage(long userId)
    {
        InitializeComponent();
        this._productRepository = new ProductRepository();
        UserId = userId;
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await RefreshAsync();
    }

    public async Task RefreshAsync()
    {
        wrpDisserts.Children.Clear();
        var products = await _productRepository.GetAllByCategoryIdAsync(3);

        foreach (var product in products)
        {
            var productViewUserControl = new ProductViewUserControl(UserId);
            productViewUserControl.SetData(product);
            wrpDisserts.Children.Add(productViewUserControl);
        }
    }

    private async void tbSearch_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            wrpDisserts.Children.Clear();

            var products = await _productRepository
                .SearchByCategoryIdFromProductAsync(3, tbSearch.Text);

            foreach (var product in products)
            {
                var appointmentsViewUserControl = new ProductViewUserControl(UserId);
                appointmentsViewUserControl.SetData(product);
                wrpDisserts.Children.Add(appointmentsViewUserControl);
            }
        }
    }


}
