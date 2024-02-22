using FastFood.Constants;
using FastFood.Entites.Orders;
using FastFood.Entites.Products;
using FastFood.Enums;
using FastFood.Helpers;
using FastFood.Pages.OrderPages;
using FastFood.Repositories.Orders;
using FastFood.Repositories.Products;
using FastFood.Windows;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
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
    private readonly OrderRepository _orderRepository;

    public long Id { get; set; }
    public long UserId { get; set; }

    private readonly string? ROOTHPATH;

    public ProductViewUserControl()
    {
        InitializeComponent();
        Product = new Product();
        this._productRepository = new ProductRepository();
        this._orderRepository = new OrderRepository();
    }

    public ProductViewUserControl(long userId)
    {
        InitializeComponent();
        Product = new Product();
        this._productRepository = new ProductRepository();
        this._orderRepository = new OrderRepository();
        this.UserId = userId;
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
            DeleteUpdateCreateWindow deleteUpdateCreateWindow = new(Product);
            deleteUpdateCreateWindow.ShowDialog();
        }
        else
        {
            Order order = new()
            {
                UserId = UserId,
                Description = Product.Description,
                IsPaid = false,
                Latitude = 0,
                Longitude = 0,
                PaymentType = PaymentType.None,
                Status = OrderStatus.InQueue,
                ProductsPrice = Product.UnitPrice,
                ResultPrice = Product.UnitPrice,
                DeliveryPrice = 0,
                DeliveryId = 1,
                CreatedAt = TimeHelper.GetDateTime(),
                UpdatedAt = TimeHelper.GetDateTime(),
            };

            if (await _orderRepository.CreateAsync(order) > 0)
            {
                OrderPage orderPage = new(UserId);
                orderPage.RefreshAsync();
            }
            else
            {
                MessageBox.Show("not create order");
            }
        }
    }
}
