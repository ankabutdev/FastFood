using FastFood.Constants;
using FastFood.Entites.Orders;
using FastFood.Entites.Products;
using FastFood.Enums;
using FastFood.Helpers;
using FastFood.Pages.AlItems;
using FastFood.Pages.OrderPages;
using FastFood.Repositories.Orders;
using FastFood.Repositories.Products;
using FastFood.Windows;
using System;
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
    private readonly ProductRepository _productRepository;
    private readonly OrderRepository _orderRepository;
    private readonly OrderDetailsRepository _orderDetailsRepository;

    public long Id { get; set; }
    public long UserId { get; set; }

    public ProductViewUserControl()
    {
        InitializeComponent();
        this._productRepository = new ProductRepository();
        this._orderRepository = new OrderRepository();
        this._orderDetailsRepository = new OrderDetailsRepository();
    }

    public ProductViewUserControl(long userId)
    {
        InitializeComponent();
        this._productRepository = new ProductRepository();
        this._orderRepository = new OrderRepository();
        this._orderDetailsRepository = new OrderDetailsRepository();
        this.UserId = userId;
    }

    public void SetData(Product product)
    {
        Id = product.Id;
        this.Product = product;
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
                ProductId = Product.Id,
                Quantity = 1,
                CreatedAt = TimeHelper.GetDateTime(),
                UpdatedAt = TimeHelper.GetDateTime(),
            };

            if (await _orderRepository.CreateAsync(order) > 0)
            {
                OrderPage orderPage = new(UserId);

                var orderDetailsNeedModel = await _orderRepository
                    .GetOrderByUserIdByProductId(UserId, Product.Id);

                OrderDetail orderDetail = new()
                {
                    OrderId = orderDetailsNeedModel.Id,
                    ProductId = Product.Id,
                    Quantity = 1,
                    TotalPrice = Product.UnitPrice * Product.Qunatity,
                    ResultPrice = (Product.UnitPrice * Product.Qunatity) - 0, /* Product.Discount */
                    DiscountPrice = 1,
                    UserId = UserId,
                    CreatedAt = TimeHelper.GetDateTime(),
                    UpdatedAt = TimeHelper.GetDateTime(),
                };

                await _orderDetailsRepository.CreateAsync(orderDetail);
            }
            //else => Error
        }
        AllItemsPage allItemsPage = new(UserId);
        allItemsPage.RefreshAsync();
    }
}
