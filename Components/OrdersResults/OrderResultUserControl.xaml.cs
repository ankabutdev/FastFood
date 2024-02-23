using FastFood.Entites.Orders;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

#pragma warning disable

namespace FastFood.Components.OrdersResults;

/// <summary>
/// Interaction logic for OrderResultUserControl.xaml
/// </summary>
public partial class OrderResultUserControl : UserControl
{
    public OrderResultUserControl()
    {
        InitializeComponent();
        //DataContext = this;
    }

    private int _productCount;

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
        ProductCount++;
    }

    private void lblMinus_Click(object sender, RoutedEventArgs e)
    {
        if (ProductCount > 0)
        {
            ProductCount--;
        }
    }

    private void UserControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        //stpOrdersChips.Children.Clear();
        //var orders = await
        MessageBox.Show("User control Mouse down");
    }

    public void SetData(Order? order)
    {
        if (order is not null)
        {
            lblOrderName.Content = order.Description;
            lblPrice.Content = order.ResultPrice.ToString();
            lblCount.Content = 0;
        }
        else
            MessageBox.Show("Order is null");
    }

}
