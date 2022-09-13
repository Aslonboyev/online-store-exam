using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using OnlineStore.UI.Pages;
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

        public MainWindow()
        {
            _userService = new UserService();

            InitializeComponent();
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

            if (Usernametxt.Text is not null || Passwordtxt.Password is not null)
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
                }
            }
        }

        private void CreateBtn(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();

            registerPage.Show();

            this.Close();
        }
    }
}
