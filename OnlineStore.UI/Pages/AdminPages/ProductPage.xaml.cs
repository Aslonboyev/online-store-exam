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
            for (int i = 0; i < users.Count; i++)
                await this.Dispatcher.InvokeAsync(() =>
                {
                    ProductItem userItem = new ProductItem();
                    userItem.IdCtn.Content = i + 1;
                    userItem.NameCtn.Content = users[i].Name;
                    userItem.DescriptionCtn.Content = users[i].Description;
                    userItem.PriceCtn.Content = users[i].Price;
                    userItem.QuantityCtn.Content = users[i].Quantity;
                    userItem.CategryCtn.Content = users[i].Category;
                    userItem.DeleteBtn.Uid = $"Id{users[i].Id}";
                    userItem.UpdateBtn.Uid = $"Id{users[i].Id}";

                    ProductListCtn.Children.Add(userItem);
                });
            }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {

            UserCreate userCreate = new UserCreate();
            System.Environment.Exit(0);

            userCreate.Show();
        }
    }
}
