using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using OnlineStore.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace OnlineStore.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUserService _userService;
        private readonly RegisterPage registerPage;

        public MainWindow()
        {
            registerPage = new RegisterPage();

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
                bool result = await _userService.LogInAsync(Usernametxt.Text, Passwordtxt.Password);

                if (result)
                {
                    registerPage.Show();
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
            registerPage.Show();

            this.Close();
        }
    }
}
