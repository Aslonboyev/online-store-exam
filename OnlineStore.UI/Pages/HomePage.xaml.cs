using Microsoft.EntityFrameworkCore;
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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

        public void CartBtn(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private async void SearchBar_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            ProductList.Children.Clear();

            string text = textBox.Text.ToString().ToLower();

            if (text.Length > 2)
            {
                thread = new Thread(async () =>
                {
                    var response = await productService.GetAllAsync(p => p.Name.ToLower().Contains(text)
                        || p.Description.ToLower().Contains(text));

                    ALlProducts = response.Data;

                    await LoadProducts(ALlProducts);
                });
                thread.Start();
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            thread = new Thread(async () =>
            {
                Dispatcher.Invoke(() => CategoryList.Children.Clear());
                Dispatcher.Invoke(() => ProductList.Children.Clear());

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
                    Button button = new Button()
                    {
                        Background = new SolidColorBrush(Color.FromRgb(36,47,61)),
                    };
                    button.Click += CategoryBtn_Click;
                    categoryItem.CategoryNameCtn.Text = category.Name;
                    button.Content = categoryItem;
                    
                    CategoryList.Children.Add(button);
                });
            }
        }

        private async void CategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductList.Children.Clear();
            string text = (((sender as Button).Content as CategoryItem).Content as TextBlock).Text;
            var products = (await productService.GetAllAsync()).Data.Include(c => c.Category).
                Where(p => p.Category.Name == text).ToList();
            await LoadProducts(products);
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

                    ProductList.Children.Add(productItem);
                });
            }
        }
    }
}
