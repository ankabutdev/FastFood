using FastFood.Constants;
using FastFood.Repositories.Products;
using FastFood.Windows.Product;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace FastFood.Windows;

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
        var product = await _productRepository.GetByIdAsync(Product.Id);

        var result = await _productRepository.DeleteAsync(Product.Id);

        var imageResult = await DeleteImage(product.ImagePath,
            ContentConstant.GetImageRootPath());

        if (result > 0 && imageResult)
        {
            MessageBox.Show("Deleted successfully");
            this.Close();
        }
    }

    private async Task<bool> DeleteImage(string imgPath, string destiantionPath = null!)
    {
        return await Task.Run(() =>
        {
            var imagePath = Path.Combine(destiantionPath, imgPath);
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
                return true;
            }
            return false;
        });
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        ProductUpdateWindow productUpdateWindow = new(Product.Id);
        productUpdateWindow.SetData(Product);
        productUpdateWindow.ShowDialog();
        this.Close();
    }
}
