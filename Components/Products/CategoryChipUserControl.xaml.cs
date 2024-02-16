using FastFood.Entites.Categories;
using FastFood.Entites.Users;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

#pragma warning disable

namespace FastFood.Components.Products;

/// <summary>
/// Interaction logic for CategoryChipUserControl.xaml
/// </summary>
public partial class CategoryChipUserControl : UserControl
{
    public Func<long, Task> Refresh { get; set; }
    private Category category = new Category();
    User User { get; set; } = new User();

    public CategoryChipUserControl()
    {
        InitializeComponent();
    }

    public void SetData(Category category)
    {
        this.category = category;
        lbCategory.Content = category.Name;
    }

    private async void UserControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        await Refresh(category.Id);
    }
}
