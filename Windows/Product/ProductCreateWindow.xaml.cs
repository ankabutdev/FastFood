using FastFood.Entites.Categories;
using FastFood.Entites.Products;
using FastFood.Helpers;
using FastFood.Repositories.Products;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FastFood.Windows
{
    /// <summary>
    /// Interaction logic for ProductCreateWindow.xaml
    /// </summary>
    public partial class ProductCreateWindow : Window
    {
        private ProductRepository _productRepository;

        public ProductCreateWindow()
        {
            InitializeComponent();
            this._productRepository = new ProductRepository();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //var product = await _productRepository.GetAllAsync();
            //cmbCourses.ItemsSource = product;


            //var category = await _categoryRepository.GetAllAsync()
            //cmbCategories.ItemsSource = courses;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //var category = GetDateFromUI();
            //category.Id = (short)await _categoryRepository.GetLatestGroupNumberByCourseAsync(category.CourseId);
            //category.Number++;
            //var result = await _productRepository.CreateAsync(category);
            //if (result > 0)
            //{
            //    MessageBox.Show("Successfully");
            //    this.Close();
            //}
        }
        //private Category GetDateFromUI()
        //{
        //    Category category = new Category();
        //    category.Id = (long)cmbCategories.SelectedValue;
        //    category.Name = cmbCategories.SelectedValuePath;
        //    category.Description = new TextRange(rbDescription.Document.ContentStart, rbDescription.Document.ContentEnd).Text;
        //    category.CreatedAt = category.UpdatedAt = TimeHelper.GetDateTime();
        //    return category;
        //}

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
