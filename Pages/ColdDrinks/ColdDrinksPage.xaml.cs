using FastFood.Components.Products;
using FastFood.Interfaces.Products;
using FastFood.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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