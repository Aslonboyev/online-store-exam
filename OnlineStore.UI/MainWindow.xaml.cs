using OnlineStore.Domain.Entities.Categories;
using OnlineStore.Domain.Entities.Locations;
using OnlineStore.Domain.Entities.Products;
using OnlineStore.Domain.Entities.Users;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using OnlineStore.UI.Pages;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace OnlineStore.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUserService _userService;
        public static List<long> ProductsBoxWIthId { get; set; }
        public static List<int> ProductCount { get; set; }
        public static long Id { get; set; }
        public static List<User> AllUsers { get; set; }
        public static List<Product> AllProducts { get; set; }
        public static List<Category> Categories { get; set; }
        public static List<Location> Locations { get; set; }
        public static bool IsAdmin { get; set; } = false;
        public static Category Category { get; set; } = null;

        public MainWindow()
        {
            InitializeComponent();
            _userService = new UserService();
            ProductsBoxWIthId = new List<long>();
            ProductCount = new List<int>();
            AllUsers = new List<User>();
            AllProducts = new List<Product>();
            Categories = new List<Category>();
            Locations = new List<Location>();
            Category = new Category();
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private async void LogInBtn(object sender, RoutedEventArgs e)
        {
            if(Usernametxt.Text.ToString() == "admin" && Passwordtxt.Password.ToString() == "1234")
            {
                IsAdmin = true;

                MainPage mainPage = new MainPage(0, null);
                mainPage.Show();
                this.Close();
            }

            else if (!string.IsNullOrEmpty(Usernametxt.Text) && !string.IsNullOrEmpty(Passwordtxt.Password))
            {
                var result = await _userService.LogInAsync(Usernametxt.Text, Passwordtxt.Password);

                if (result.Data is not null)
                {
                    MainPage mainPage = new MainPage(result.Data.Id, result.Data.FirstName);

                    Id = result.Data.Id;

                    mainPage.Show();
                    this.Close();
                }
                else
                {
                    Usernametxt.Clear();
                    Passwordtxt.Clear();
                    MessageBox.Show("Wrong username or password", "Please double check!");
                }
            }
        }

        private void CreateBtn(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();

            registerPage.Show();

            this.Close();
        }

        private void Passwordtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LogInBtn(sender, e);
            }
        }
    }
}
