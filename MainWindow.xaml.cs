using FastFood.Entites.Users;
using FastFood.Enums;
using FastFood.Pages.AddProducts;
using FastFood.Pages.AlItems;
using FastFood.Pages.ColdDrinks;
using FastFood.Pages.Disserts;
using FastFood.Pages.Foods;
using FastFood.Pages.HotDrinks;
using System.Windows;
using System.Windows.Input;

namespace FastFood;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public static User User { get; set; } = new User();

    public MainWindow(IdentityRole Role)
    {
        InitializeComponent();

        // Is_Admin
        User.Role = Role;

        if (User.Role is IdentityRole.Admin)
        {
            rbCreateProducts.Visibility = Visibility.Visible;
            PageResultNavigator.Visibility = Visibility.Collapsed;
            drResult.Visibility = Visibility.Collapsed;
        }
        else
        {
            rbCreateProducts.Visibility = Visibility.Collapsed;
            PageResultNavigator.Visibility = Visibility.Visible;
            drResult.Visibility = Visibility.Visible;
        }
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
        ColdDrinksPage coldDrinksPage = new ColdDrinksPage();
        PageNavigator.Content = coldDrinksPage;
    }

    private void rbHotDrinks_Click(object sender, RoutedEventArgs e)
    {
        HotDrinksPage hotDrinksPage = new HotDrinksPage();
        PageNavigator.Content = hotDrinksPage;
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

    private void rbDisserts_Click(object sender, RoutedEventArgs e)
    {
        DissertsPage dissertsPage = new DissertsPage();
        PageNavigator.Content = dissertsPage;
    }

    private void rbCreateProduct_Click(object sender, RoutedEventArgs e)
    {
        PageResultNavigator.Visibility = Visibility.Collapsed;
        CreateProductPage createProductPage = new CreateProductPage();
        PageNavigator.Content = createProductPage;
    }

    private void rbLogout_Click(object sender, RoutedEventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
        this.Close();
    }
}
