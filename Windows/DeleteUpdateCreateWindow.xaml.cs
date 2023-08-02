using FastFood.Repositories.Products;
using FastFood.Windows.Product;
using System.Windows;

namespace FastFood.Windows
{
    /// <summary>
    /// Interaction logic for DeleteUpdateCreateWindow.xaml
    /// </summary>
    public partial class DeleteUpdateCreateWindow : Window
    {
        private readonly ProductRepository _productRepository;

        private Entites.Products.Product Product { get; set; }

        public DeleteUpdateCreateWindow(Entites.Products.Product product)
        {
            InitializeComponent();
            this._productRepository = new ProductRepository();
            this.Product = product;
        }




        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var result = await _productRepository.DeleteAsync(Product.Id);

            if (result > 0)
            {
                MessageBox.Show("Deleted successfully");
                this.Close();
            }

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductUpdateWindow productUpdateWindow = new ProductUpdateWindow(Product.Id);
            productUpdateWindow.SetData(Product);
            productUpdateWindow.ShowDialog();
            this.Close();
        }

    }
}
