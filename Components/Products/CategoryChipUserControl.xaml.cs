using FastFood.Entites.Categories;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FastFood.Components.Products
{
    /// <summary>
    /// Interaction logic for CategoryChipUserControl.xaml
    /// </summary>
    public partial class CategoryChipUserControl : UserControl
    {
        public Func<long, Task> Refresh { get; set; }
        private Category category = new Category();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CategoryChipUserControl()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
}
