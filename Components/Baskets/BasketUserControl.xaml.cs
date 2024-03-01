using FastFood.Constants;
using FastFood.Entites.Orders;
using FastFood.Entites.Products;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FastFood.Components.Baskets;

/// <summary>
/// Interaction logic for BasketUserControl.xaml
/// </summary>
public partial class BasketUserControl : UserControl
{
    public BasketUserControl()
    {
        InitializeComponent();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
    }
    public async Task RefreshAsync()
    {
    }

    public void SetData(Order order)
    {

        string path = ContentConstant.GetImageContentsPath() + product.ImagePath;
        cmpImage.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
    }
}
