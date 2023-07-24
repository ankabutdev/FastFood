using FastFood.Pages.AlItems;
using FastFood.Pages.Foods;
using System.Windows;
using System.Windows.Input;

namespace FastFood
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else this.WindowState = WindowState.Maximized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void brDragable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void rbColdDrinks_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbHotDrinks_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rb_Food_Click(object sender, RoutedEventArgs e)
        {
            FoodPage foodPage = new FoodPage();
            PageNavigator.Content = foodPage;
        }

        private void rb_AllItems_Click(object sender, RoutedEventArgs e)
        {
            AllItemsPage allItemsPage = new AllItemsPage();
            PageNavigator.Content = allItemsPage;
        }
    }
}
