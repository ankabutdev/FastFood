using FastFood.Components.Products;
using FastFood.Entites.Products;
using FastFood.Repositories.Products;
using FastFood.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FastFood.Pages.AlItems
{
    /// <summary>
    /// Interaction logic for AllItemsPage.xaml
    /// </summary>
    public partial class AllItemsPage : Page
    {
        private readonly ProductRepository _productRepository;

        public AllItemsPage()
        {
            InitializeComponent();
            this._productRepository = new ProductRepository();
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await RefreshAsync();
        }

        public async Task RefreshAsync()
        {
            wrpAllItems.Children.Clear();
            var products = await _productRepository.GetAllAsync();

            foreach (var product in products)
            {
                var productViewUserControl = new ProductViewUserControl();
                productViewUserControl.SetData(new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    ImagePath = product.Image,
                });
                wrpAllItems.Children.Add(productViewUserControl);
            }
        }

        private async void btnCreate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ProductCreateWindow productCreateWindow = new ProductCreateWindow();
            productCreateWindow.ShowDialog();
            await RefreshAsync();
        }
    }
}
