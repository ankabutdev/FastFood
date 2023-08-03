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

namespace FastFood.Windows.Product;

/// <summary>
/// Interaction logic for ProductUpdateWindow.xaml
/// </summary>
public partial class ProductUpdateWindow : Window
{
    private readonly CategoryRepository _categoryRepository;
    private readonly ProductRepository _productRepository;

    private long Id { get; set; }

    public ProductUpdateWindow(long Id)
    {
        InitializeComponent();
        this._categoryRepository = new CategoryRepository();
        this._productRepository = new ProductRepository();
        this.Id = Id;
    }

    public void SetData(FastFood.Entites.Products.Product product)
    {
        try
        {
            ProductDiscount productDiscount = new ProductDiscount();

            tbProductName.Text = product.Name.ToString();
            tbProductUnitPrice.Text = product.UnitPrice.ToString();
            tbProductQuantity.Text = product.Qunatity.ToString();
            rbDescription.AppendText(product.Description);
            ImgBImage.ImageSource = new BitmapImage(new Uri(product.ImagePath, UriKind.Relative));

            tbDiscount.Text = productDiscount.Percentage.ToString();
            cmbCategories.SelectedValue = product.CategoryId;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        

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


    private async Task<FastFood.Entites.Products.Product> GetDateFromUI()
    {
        FastFood.Entites.Products.Product product = new FastFood.Entites.Products.Product();

        product.Name = tbProductName.Text;
        product.CategoryId = (long)cmbCategories.SelectedValue;
        product.UnitPrice = Convert.ToDouble(tbProductUnitPrice.Text);
        product.Qunatity = Convert.ToInt64(tbProductQuantity.Text);

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

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var category = await _categoryRepository.GetAllAsync();
        cmbCategories.ItemsSource = category;
    }

    private async void btnSave_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var product = GetDateFromUI();
            var result = await _productRepository.UpdateAsync(Id, await product);
            if (result > 0)
            {
                MessageBox.Show("Successfully");
                this.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        
    }
}
