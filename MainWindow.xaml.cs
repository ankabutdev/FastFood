﻿using FastFood.Entites.Users;
using FastFood.Enums;
using FastFood.Pages.AddProducts;
using FastFood.Pages.AlItems;
using FastFood.Pages.ColdDrinks;
using FastFood.Pages.Disserts;
using FastFood.Pages.Foods;
using FastFood.Pages.HotDrinks;
using FastFood.Pages.OrderPages;
using System.Windows;
using System.Windows.Input;

namespace FastFood;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public static User User { get; set; } = new User();

    public MainWindow(IdentityRole Role, long userId)
    {
        InitializeComponent();
        Check(Role, userId);
    }

    private void Check(IdentityRole Role, long userId)
    {
        // Is_Admin
        User.Role = Role;
        User.Id = userId;

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
        ColdDrinksPage coldDrinksPage = new ColdDrinksPage(User.Id);
        PageNavigator.Content = coldDrinksPage;
        ConnectOrderPage();
    }

    private void rbHotDrinks_Click(object sender, RoutedEventArgs e)
    {
        HotDrinksPage hotDrinksPage = new HotDrinksPage(User.Id);
        PageNavigator.Content = hotDrinksPage;
        ConnectOrderPage();
    }

    private void rb_Food_Click(object sender, RoutedEventArgs e)
    {
        FoodPage foodPage = new FoodPage(User.Id);
        PageNavigator.Content = foodPage;
        ConnectOrderPage();
    }

    private void rb_AllItems_Click(object sender, RoutedEventArgs e)
    {
        AllItemsPage allItemsPage = new AllItemsPage(User.Id);
        PageNavigator.Content = allItemsPage;
        ConnectOrderPage();
    }

    private void rbDisserts_Click(object sender, RoutedEventArgs e)
    {
        DissertsPage dissertsPage = new DissertsPage(User.Id);
        PageNavigator.Content = dissertsPage;
        ConnectOrderPage();
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

    private void ConnectOrderPage()
    {
        OrderPage orderPage = new OrderPage(User.Id);
        PageResultNavigator.Content = orderPage;
    }

    private void PayForOrders_Click(object sender, RoutedEventArgs e)
    {
        OrderPage orderPage = new(User.Id);
    }
}
