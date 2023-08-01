using FastFood.Entites.Products;
using FastFood.Enums;
using FastFood.Repositories.Products;
using FastFood.Windows;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FastFood.Components.Products;

/// <summary>
/// Interaction logic for ProductViewUserControl.xaml
/// </summary>
public partial class ProductViewUserControl : UserControl
{

    public Product Product { get; set; }

    private ProductRepository _productRepository;

    public long Id { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ProductViewUserControl()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        InitializeComponent();
        Product = new Product();                                                   //////////////////////////////
        this._productRepository = new ProductRepository();
    }

    public void SetData(Product product)
    {
        Id = product.Id;
        ProductName.Content = product.Name;
        lblProductPrice.Content = product.UnitPrice.ToString() + " $";
        string path = product.ImagePath;
        cmpImage.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
    }

    private async void grMain_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Product = await _productRepository.GetByIdAsync(Id);

        if (MainWindow.User.Role == IdentityRole.Admin)
        {
            DeleteUpdateCreateWindow deleteUpdateCreateWindow = new DeleteUpdateCreateWindow(Product);
            deleteUpdateCreateWindow.ShowDialog();
        }
        else
        {
            MessageBox.Show("User");
        }
    }
}
