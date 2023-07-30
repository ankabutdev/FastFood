﻿using FastFood.Components.Products;
using FastFood.Entites.Products;
using FastFood.Repositories.Categories;
using FastFood.Repositories.Products;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FastFood.Pages.AddProducts
{
    /// <summary>
    /// Interaction logic for CreateProductPage.xaml
    /// </summary>
    public partial class CreateProductPage : Page
    {
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private object stpProductChips;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CreateProductPage()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            this._categoryRepository = new CategoryRepository();
            this._productRepository = new ProductRepository();
        }

        private async Task RefreshAsync(long categoryId)
        {
            wrpTeachers.Children.Clear();
            IList<Product> products;
            if (categoryId == 0)
            {
                products = (IList<Product>)await _productRepository.GetAllAsync();
            }
            else
            {
                products = await _productRepository.GetAllByCategoryIdAsync(categoryId);
            }

            foreach (var product in products)
            {
                CreateProductPage viewcontrol = new CreateProductPage();
                viewcontrol.SetData(product);
                wrpTeachers.Children.Add(viewcontrol);
            }
        }

        private void SetData(Product product)
        {

        }

        private void btnCreate_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private async void Create_Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //stpCategoriesChips.Children.Clear();
            //var category = await _categoryRepository.GetAllAsync();
            //// for all
            //CategoryChipUserControl allforship = new CategoryChipUserControl();
            //allforship.SetData(new Entites.Categories.Category() { Id = 0, Name = "All" });
            //allforship.Refresh = RefreshAsync;
            //stpCategoriesChips.Children.Add(allforship);
            //foreach (var cat in category)
            //{
            //    CategoryChipUserControl categoryChipUserControl = new CategoryChipUserControl();
            //    categoryChipUserControl.Refresh = RefreshAsync;
            //    categoryChipUserControl.SetData((Entites.Categories.Category)cat);
            //    stpCategoriesChips.Children.Add(categoryChipUserControl);
            //}

            //await RefreshAsync(0);
        }
    }
}