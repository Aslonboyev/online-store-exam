using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using System.Windows;

namespace OnlineStore.UI.Pages.UserPages
{
    /// <summary>
    /// Interaction logic for UserDeletePage.xaml
    /// </summary>
    public partial class UserDeletePage : Window
    {
        private readonly long _id;

        private readonly IUserService userService;

        public UserDeletePage(long id)
        {
            InitializeComponent();

            userService = new UserService();

            _id = id;
        }

        private async void UserDeletedBtn(object sender, RoutedEventArgs e)
        {
            var result = await userService.DeleteAsync(p => p.Id == _id);

            if (result.Data)
            {
                RegisterPage registerPage = new RegisterPage();

                registerPage.Show();

                this.Close();
            }
        }
    }
}
