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
using System.Windows.Shapes;

namespace FastFood.Windows.Payment;

/// <summary>
/// Interaction logic for PaymentWindow.xaml
/// </summary>
public partial class PaymentWindow : Window
{
    public PaymentWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await RefreshAsync();
    }

    public async Task RefreshAsync()
    {
        wrpBasket.Children.Clear();


    }
}
