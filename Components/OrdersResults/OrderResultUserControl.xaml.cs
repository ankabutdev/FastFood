using FastFood.Entites.Orders;
using System;
using System.Windows.Controls;

namespace FastFood.Components.OrdersResults;

/// <summary>
/// Interaction logic for OrderResultUserControl.xaml
/// </summary>
public partial class OrderResultUserControl : UserControl
{
    public OrderResultUserControl()
    {
        InitializeComponent();
    }

    private void UserControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        //stpOrdersChips.Children.Clear();
        //var orders = await 
    }

    public void SetData(Order order)
    {
        order.ProductsPrice = Convert.ToDouble(lblPrice.Content);
    }

}
