using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
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
using System.Windows.Shapes;

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
