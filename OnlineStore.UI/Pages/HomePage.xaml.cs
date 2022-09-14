using OnlineStore.Domain.Entities.Categories;
using OnlineStore.Domain.Entities.Products;
using OnlineStore.Service.DTOs.CategoryDTOs;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using OnlineStore.UI.Pages.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OnlineStore.UI.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private ICategoryService categoryService;
        
        private IProductService productService;

        private IEnumerable<Category> AllCategories;

        private IEnumerable<Product> ALlProducts;

        private Thread thread;

        public HomePage()
        {
            InitializeComponent();

            productService = new ProductService();

            categoryService = new CategoryService();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            CartName.Text = "";
        }

        private void CartBtn(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private async void SearchBar_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            ProductList.Items.Clear();

            string text = textBox.Text.ToString().ToLower();

            if (text.Length > 3)
            {
                thread = new Thread(async () =>
                {
                    var response = await productService.GetAllAsync();

                    ALlProducts = response.Data;

                    ALlProducts = ALlProducts.Where(p => p.Name.ToLower().Contains(text)
                        || p.Description.ToLower().Contains(text));

                    await LoadProducts(ALlProducts);
                });
                thread.Start();
            }
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            thread = new Thread(async () =>
            {
                Dispatcher.Invoke(() => CategoryList.Items.Clear());
                Dispatcher.Invoke(() => ProductList.Items.Clear());

                var response = await categoryService.GetAllAsync();
                AllCategories = response.Data;

                var response1 = await productService.GetAllAsync();
                ALlProducts = response1.Data;

                await LoadCategories(AllCategories);
                await LoadProducts(ALlProducts);
            });

            thread.Start();
        }

        private async Task LoadCategories(IEnumerable<Category> categories)
        {
            foreach (var category in categories)
            {
                await this.Dispatcher.InvokeAsync(() =>
                {
                    CategoryItem categoryItem = new CategoryItem();
                    categoryItem.CategoryNameCtn.Content = category.Name;
                    
                    CategoryList.Items.Add(categoryItem);
                });
            }
        }
        private async Task LoadProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                await this.Dispatcher.InvokeAsync(() =>
                {
                    ProductItem productItem = new ProductItem();
                    productItem.PriceCtn.Content = product.Price;
                    productItem.ProductDescriptionCtn.Content = product.Description;
                    productItem.ProductNameCtn.Content = product.Name;
                    productItem.ProductImage.Source = new BitmapImage(new Uri(product.ImagePath));

                    CategoryList.Items.Add(productItem);
                });
            }
        }
    }
}
