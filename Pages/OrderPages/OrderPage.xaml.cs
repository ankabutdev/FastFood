using FastFood.Components.OrdersResults;
using FastFood.Components.Products;
using FastFood.Entites.Categories;
using FastFood.Repositories.Categories;
using FastFood.Repositories.Orders;
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

namespace FastFood.Pages.OrderPages;

/// <summary>
/// Interaction logic for OrderPage.xaml
/// </summary>
public partial class OrderPage : Page
{
    private readonly OrderRepository _orderRepository;
    private readonly ProductRepository _productRepository;
    private readonly CategoryRepository _categoryRepository;

    public OrderPage()
    {
        InitializeComponent();
        this._orderRepository = new OrderRepository();
        this._productRepository = new ProductRepository();
        this._categoryRepository = new CategoryRepository();
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        wrpOrder.Children.Clear();
        var order = await _orderRepository.GetAllAsync();

        OrderResultUserControl all = new OrderResultUserControl();
        wrpOrder.Children.Add(all);
        foreach (var ord in order)
        {
            var orderResultUserControl = new OrderResultUserControl();
            orderResultUserControl.SetData(ord);
            wrpOrder.Children.Add(orderResultUserControl);
        }
    }
}
