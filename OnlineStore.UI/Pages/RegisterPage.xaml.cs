using OnlineStore.Service.DTOs.UserDTOs;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using System.Windows;

namespace OnlineStore.UI.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        private readonly IUserService _userService;

        public RegisterPage()
        {
            _userService = new UserService();

            InitializeComponent();
        }
        private async void SignUpBtn(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            if (passwordtxt.Password == repeatPasswordtxt.Password && usernametxt.Text is not null &&
                firstnametxt.Text is not null && lastnametxt.Text is not null && emailtxt.Text is not null &&
                phonetxt.Text is not null && passwordtxt.Password is not null && Check.IsChecked is true)
            {
                UserCreationDTO userCreationDTO = new UserCreationDTO()
                {
                    Username = usernametxt.Text,
                    Password = passwordtxt.Password,
                    FirstName = firstnametxt.Text,
                    LastName = lastnametxt.Text,
                    Email = emailtxt.Text,
                    Phone = phonetxt.Text,
                };

                var result = await _userService.CreateAsync(userCreationDTO);

                if (result.Data.FirstName is not null)
                {
                    mainWindow.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Check your details. \nYour details are already taken or wrong!");
            }
        }

        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            this.Close();
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
