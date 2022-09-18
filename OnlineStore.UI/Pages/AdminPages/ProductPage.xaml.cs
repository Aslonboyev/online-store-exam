using OnlineStore.Domain.Entities.Products;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using OnlineStore.UI.Pages.AdminPages.AllComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineStore.UI.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private readonly IProductService productService;
        private Thread thread;
        private List<Product> AllProducts;
        public ProductPage()
        {
            InitializeComponent();
            productService = new ProductService();
            AllProducts = new List<Product>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            thread = new Thread(async () =>
            {
                Dispatcher.Invoke(() => ProductListCtn.Children.Clear());

                var response = await productService.GetAllAsync();
                MainWindow.AllProducts = response.Data.ToList();

                await LoadUsers(MainWindow.AllProducts);
            });

            thread.Start();
        }

        private async Task LoadUsers(List<Product> users)
        {
            foreach (var user in users)
            {
                await this.Dispatcher.InvokeAsync(() =>
                {
                    ProductItem userItem = new ProductItem();
                    userItem.IdCtn.Content = user.Id+1;
                    userItem.NameCtn.Content = user.Name;
                    userItem.DescriptionCtn.Content = user.Description;
                    userItem.PriceCtn.Content = user.Price;
                    userItem.QuantityCtn.Content = user.Quantity;
                    userItem.CategryCtn.Content = user.Category;

                    ProductListCtn.Children.Add(userItem);
                });
            }
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            UserCreate userCreate = new UserCreate();
            System.Environment.Exit(0);

            userCreate.Show();

        }
    }
}
