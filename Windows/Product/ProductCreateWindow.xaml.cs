using FastFood.Constants;
using FastFood.Entites.Products;
using FastFood.Helpers;
using FastFood.Repositories.Categories;
using FastFood.Repositories.Products;
using Microsoft.Win32;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace FastFood.Windows
{
    /// <summary>
    /// Interaction logic for ProductCreateWindow.xaml
    /// </summary>
    public partial class ProductCreateWindow : Window
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;

        public ProductCreateWindow()
        {
            InitializeComponent();
            this._productRepository = new ProductRepository();
            this._categoryRepository = new CategoryRepository();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var category = await _categoryRepository.GetAllAsync();
            cmbCategories.ItemsSource = category;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var product = GetDateFromUI();
            var result = await _productRepository.CreateAsync(await product);
            if (result > 0)
            {
                MessageBox.Show("Successfully");
                this.Close();
            }
        }
        private async Task<Product> GetDateFromUI()
        {
            Product product = new Product();

            product.Name = tbProductName.Text;
            product.CategoryId = (long)cmbCategories.SelectedValue;
            product.UnitPrice = Convert.ToDouble(tbProductUnitPrice.Text);

            product.Description = new TextRange(rbDescription.Document.ContentStart,
                rbDescription.Document.ContentEnd).Text;

            string imagepath = ImgBImage.ImageSource.ToString();
            if (!String.IsNullOrEmpty(imagepath))
                product.ImagePath = await CopyImageAsync(imagepath,
                     ContentConstant.IMAGE_CONTENTS_PATH);

            product.CreatedAt = product.UpdatedAt =
                    TimeHelper.GetDateTime();

            return product;
        }

        private void btnImageSelector_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = GetImageDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string imgPath = openFileDialog.FileName;
                ImgBImage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }
        }

        private OpenFileDialog GetImageDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
            return openFileDialog;
        }

        private async Task<string> CopyImageAsync(string imgPath, string destinationDirectory)
        {
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            var imageName = ContentNameMaker.GetImageName(imgPath);

            string path = System.IO.Path.Combine(destinationDirectory, imageName);

            byte[] image = await File.ReadAllBytesAsync(imgPath);

            await File.WriteAllBytesAsync(path, image);

            return path;
        }
    }
}
