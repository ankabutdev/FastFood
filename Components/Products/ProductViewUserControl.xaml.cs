using FastFood.Entites.Products;
using FastFood.ViewModels.Products;
using System;
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
        public long Id { get; private set; }

        public ProductViewUserControl()
        {
            InitializeComponent();
        }


        private void grMain_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        //public void SetData(ProductViewModel productViewModel)
        //{
        //    ProductName.Content = productViewModel.Name;
        //    lblProductPrice.Content = productViewModel.Price;
        //}


        public void SetData(Product product)
        {
            Id = product.Id;
            cmpPlusMinus.Source = new BitmapImage(new System.Uri(product.ImagePath, UriKind.Relative));
            ProductName.Content = product.Name;
        }
    }
}
