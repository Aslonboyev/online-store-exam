using OnlineStore.Domain.Entities.Users;
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
    /// Interaction logic for UserDetailPage.xaml
    /// </summary>
    public partial class UserDetailPage : Window
    {
        private User _user;

        public UserDetailPage(User user)
        {
            InitializeComponent();
            
            _user = user;

            FirstnameCtn.Content = _user.FirstName;
            LastnameCtn.Content = _user.LastName;
            EmialCtn.Content = _user.Email;
            PhoneCtn.Content = _user.Phone;
            UsernameCtn.Content = _user.Username;

        }

        private void BackToStore(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage(_user.Id, _user.FirstName);

            mainPage.Show();

            this.Close();
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UserDeleteBtn(object sender, RoutedEventArgs e)
        {
            UserDeletePage userDeletePage = new UserDeletePage(_user.Id);

            userDeletePage.Show();

            this.Close();
        }

        private void UserUpdateBtn(object sender, RoutedEventArgs e)
        {
            UserUpdatePage userUpdatePage = new UserUpdatePage(_user.Id);

            userUpdatePage.Show();

            this.Close();
        }
    }
}
