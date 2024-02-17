using FastFood.Constants;
using FastFood.Entites.Products;
using FastFood.Enums;
using FastFood.Repositories.Products;
using FastFood.Windows;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

#pragma warning disable

namespace FastFood.Components.Products;

/// <summary>
/// Interaction logic for ProductViewUserControl.xaml
/// </summary>
public partial class ProductViewUserControl : UserControl
{

    public Product Product { get; set; }
    private IWebHostEnvironment? _env;

    private readonly ProductRepository _productRepository;

    public long Id { get; set; }
    private readonly string? ROOTHPATH;


    public ProductViewUserControl()
    {
        InitializeComponent();
        Product = new Product();
        this._productRepository = new ProductRepository();
    }

    public void SetData(Product product)
    {
        Id = product.Id;
        ProductName.Content = product.Name;
        lblProductPrice.Content = product.UnitPrice.ToString() + " $";
        string path = ContentConstant.GetImageContentsPath() + product.ImagePath;
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
