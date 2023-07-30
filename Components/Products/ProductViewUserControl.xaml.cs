using FastFood.Entites.Products;
using FastFood.ViewModels.Products;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FastFood.Components.Products
{
    /// <summary>
    /// Interaction logic for ProductViewUserControl.xaml
    /// </summary>
    public partial class ProductViewUserControl : UserControl
    {
        public Product Product { get; set; }
        public long Id { get; private set; }

        public ProductViewUserControl()
        {
            InitializeComponent();
            Product = new Product();
        }

        private void grMain_MouseDown(object sender, MouseButtonEventArgs e)
        {

            MessageBox.Show(Id.ToString());
        }

        public void SetData(Product product)
        {
            Id = product.Id;
            ProductName.Content = product.Name;
            lblProductPrice.Content = product.UnitPrice;
            cmpImage.Source = new BitmapImage(new Uri(product.ImagePath, UriKind.Relative));
        }

        public void SetData(ProductViewModel product)
        {
            Id = product.Id;
            ProductName.Content = product.Name;
            lblProductPrice.Content = product.UnitPrice;
            cmpImage.Source = new BitmapImage(new Uri(product.ImagePath, UriKind.Relative));
        }
    }
}
