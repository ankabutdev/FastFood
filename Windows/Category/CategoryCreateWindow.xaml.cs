using FastFood.Constants;
using FastFood.Helpers;
using FastFood.Repositories.Categories;
using Microsoft.Win32;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace FastFood.Windows.Category;

/// <summary>
/// Interaction logic for CategoryCreateWindow.xaml
/// </summary>
public partial class CategoryCreateWindow : Window
{
    private CategoryRepository _categoryRepository;

    public CategoryCreateWindow()
    {
        InitializeComponent();
        _categoryRepository = new CategoryRepository();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {

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

    private async void btnSave_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var category = GetDataFromUI();
            var result = await _categoryRepository.CreateAsync(await category);
            if (result > 0)
            {
                MessageBox.Show("Seccessfully");
                this.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private async Task<Entites.Categories.Category> GetDataFromUI()
    {
        var category = new Entites.Categories.Category();
        category.Name = tbCategoryName.Text;
        category.Description = new TextRange(rbDescription.Document.ContentStart,
            rbDescription.Document.ContentEnd).Text;

        string imagePath = ImgBImage.ImageSource.ToString();
        if (!string.IsNullOrEmpty(imagePath))
            category.ImagePath = await CopyToImageAsync(imagePath,
                ContentConstant.GetImageRootPath());

        category.CreatedAt = category.UpdatedAt =
            TimeHelper.GetDateTime();

        return category;
    }

    private OpenFileDialog GetImageDialog()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
        return openFileDialog;
    }

    private async Task<string> CopyToImageAsync(string imgPath, string destinationDirectory)
    {
        if (!Directory.Exists(destinationDirectory))
            Directory.CreateDirectory(destinationDirectory);

        var imageName = ContentNameMaker.GetImageName(imgPath);

        string path = Path.Combine(destinationDirectory, imageName);

        byte[] image = await File.ReadAllBytesAsync(imgPath);

        await File.WriteAllBytesAsync(path, image);

        return path;
    }
}
