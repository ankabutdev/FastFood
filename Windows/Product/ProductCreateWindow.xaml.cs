using FastFood.Repositories.Products;
using System;
using System.Collections.Generic;
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


            //var courses = await _courseRepository.GetAllAsync(new Utils.PaginationParams()
            //{
            //    PageNumber = 1,
            //    PageSize = 100
            //});
            //cmbCourses.ItemsSource = courses;
        }
    }
}
