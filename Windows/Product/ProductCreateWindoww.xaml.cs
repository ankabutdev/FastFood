using FastFood.Constants;
using FastFood.Entites.Products;
using FastFood.Helpers;
using FastFood.Repositories.Categories;
using FastFood.Repositories.Products;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FastFood.Windows.Product;

/// <summary>
/// Interaction logic for ProductCreateWindoww.xaml
/// </summary>
public partial class ProductCreateWindoww : Window
{
    private CategoryRepository _categoryRepository;
    private ProductRepository _productRepository;

    public ProductCreateWindoww()
    {
        InitializeComponent();
        this._categoryRepository = new CategoryRepository();
        this._productRepository = new ProductRepository();
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
    private async Task<FastFood.Entites.Products.Product> GetDateFromUI()
    {
        FastFood.Entites.Products.Product product = new FastFood.Entites.Products.Product();
        ProductDiscount productDiscount = new ProductDiscount();
        ProductSupplier productSupplier = new ProductSupplier();

        product.Name = tbProductName.Text;
        product.CategoryId = (long)cmbCategories.SelectedValue;
        product.UnitPrice = Convert.ToDouble(tbProductUnitPrice.Text);
        product.Qunatity = Convert.ToInt64(tbProductQuantity.Text);

        productSupplier.ProductId = productDiscount.ProductId = product.Id;

        product.Description = new TextRange(rbDescription.Document.ContentStart,
            rbDescription.Document.ContentEnd).Text;

        productDiscount.Percentage = short.Parse(tbDiscount.Text);

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