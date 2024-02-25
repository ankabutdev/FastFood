using FastFood.Entites.Orders;
using FastFood.Repositories.Orders;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

#pragma warning disable

namespace FastFood.Components.OrdersResults;

/// <summary>
/// Interaction logic for OrderResultUserControl.xaml
/// </summary>
public partial class OrderResultUserControl : UserControl
{
    public Func<long, Task> Refresh { get; set; }
    private Order Order = new();
    private readonly OrderRepository _orderRepository;

    public OrderResultUserControl()
    {
        InitializeComponent();
        this._orderRepository = new();
    }

    private int _productCount = 1;

    public int ProductCount
    {
        get { return _productCount; }
        set
        {
            if (_productCount != value)
            {
                _productCount = value;
                OnPropertyChanged(nameof(ProductCount));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        ProductCount += 1;
        lblCount.Content = ProductCount;
    }

    private void lblMinus_Click(object sender, RoutedEventArgs e)
    {
        if (ProductCount > 1)
        {
            ProductCount -= 1;
        }
        lblCount.Content = ProductCount;
    }

    private async void UserControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        // 
    }

    public void SetData(Order order)
    {
        this.Order = order;
        lblOrderName.Content = order.Description;
        lblPrice.Content = order.ResultPrice.ToString() + " $";
        lblCount.Content = 1;
    }

    private async void Delete_Button_Click(object sender, RoutedEventArgs e)
    {
        if (await _orderRepository.DeleteAsync(Order.Id) > 0)
        {
            MessageBox.Show("Successfully");
        }
    }
}
