using OnlineStore.Domain.Entities.Products;
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

        public MainWindow()
        {
            InitializeComponent();
            _userService = new UserService();
            ProductsBoxWIthId = new List<long>();
            ProductCount = new List<int>();
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

            if (!string.IsNullOrEmpty(Usernametxt.Text) && !string.IsNullOrEmpty(Passwordtxt.Password))
            {
                var result = await _userService.LogInAsync(Usernametxt.Text, Passwordtxt.Password);

                if (result.Data is not null)
                {
                    MainPage mainPage = new MainPage(result.Data.Id, result.Data.FirstName);

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
