using AutoMapper.Execution;
using OnlineStore.Domain.Entities.Orders;
using OnlineStore.Domain.Entities.Products;
using OnlineStore.Service.DTOs.OrderDTOs;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using OnlineStore.UI.Pages.UserPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace OnlineStore.UI.Pages.HomePages
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        private readonly IProductService _productService;

        private readonly IOrderService _orderService;

        private readonly IOrderDetailService _orderDetailService;

        private Thread thread;
        
        private List<Product> products;

        private Decimal Total { get; set; }
        
        public CartPage()
        {
            InitializeComponent();

            _productService = new ProductService();
            _orderService = new OrderService();
            _orderDetailService = new OrderDetailService();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Product> product1 = new List<Product>();
            thread = new Thread(async () =>
            {
                Dispatcher.Invoke(() => FinalProductsList.Children.Clear());

                for (int i = 0; i < MainWindow.ProductsBoxWIthId.Count; i++)
                {
                    var response = await _productService.GetAsync(p => p.Id == MainWindow.ProductsBoxWIthId[i]);

                    product1.Add(response.Data);
                }
                products = product1;

                await LoadProducts(product1);

                //TotalPrice.Content = Total;
            });

            thread.Start();

        }

        private async void Checkout_Click(object sender, RoutedEventArgs e)
        {
            if (CardNumber(CardNumberCtn.Text) && IsCardDate(CardDateCtn.Text) && IsCVV(CardCVVCtn.Text))
            {
                OrderCreationDTO orderDTO = new OrderCreationDTO()
                {
                    DeleveryState = Domain.Enums.DeleveryState.InProgress,
                    Total = Total,
                    UserId = MainWindow.Id,
                    UserOpinion = Domain.Enums.UserOpinion.VeryGood,
                    LocationId = 1,
                };

                var order = await _orderService.CreateAsync(orderDTO);

                for (int i = 0; i < products.Count; i++)
                {
                    OrderDetailCreationDTO detailDTO = new OrderDetailCreationDTO()
                    {
                        OrderId = order.Data.Id,
                        ProductCount = MainWindow.ProductCount[i],
                        ProductId = products[i].Id,
                    };

                    await _orderDetailService.CreateAsync(detailDTO);
                }

                MainWindow.ProductCount.Clear();

                MainWindow.ProductsBoxWIthId.Clear();

                HomePage homePage = new HomePage();

                this.NavigationService.Navigate(homePage);

                MessageBox.Show("Thank you");
            }
            else
            {
                MessageBox.Show("Please check your card details!");
            }
        }

        private async Task LoadProducts(List<Product> products)
        {
            decimal total = 0;

            for (int i = 0; i < products.Count; i++)
            {
                await this.Dispatcher.InvokeAsync(() =>
                {
                    Item productItem = new Item();
                    productItem.ProductTotalPriceCtn.Content = products[i].Price * MainWindow.ProductCount[i];
                    productItem.ProductDescriptionCtn.Content = products[i].Description;
                    productItem.ProductNameCtn.Content = products[i].Name;
                    productItem.ProductImageCtn.Source = new BitmapImage(new Uri(products[i].ImagePath));
                    productItem.ProductCountCtn.Content = MainWindow.ProductCount[i];

                    total += products[i].Price * MainWindow.ProductCount[i];

                    TotalPrice.Content = total;

                    FinalProductsList.Children.Add(productItem);
                });
            }

            Total = total;

        }
         
        private bool CardNumber (string text)
        {
            return Regex.Match(text, @"^([0-9]{16})$").Success;
        }
        private bool IsCVV (string text)
        {
            return Regex.Match(text, @"^([0-9]{3})$").Success;
        }
        private bool IsCardDate(string text)
        {
            return Regex.Match(text, @"^([0-9]{2})/([0-9]{2})$").Success;
        }

    }
}
