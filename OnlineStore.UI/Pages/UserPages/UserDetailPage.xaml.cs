using OnlineStore.Domain.Entities.Users;
using System;
using System.Windows;
using System.Windows.Controls;

namespace OnlineStore.UI.Pages.UserPages
{
    /// <summary>
    /// Interaction logic for UserDetailPage.xaml
    /// </summary>
    public partial class UserDetailPage : Page
    {
        private User _user;

        public UserDetailPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _user = MainPage.UserDetailData;

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
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {

        }

        private void UserDeleteBtn(object sender, RoutedEventArgs e)
        {
            UserDeletePage userDeletePage = new UserDeletePage(_user.Id);

            userDeletePage.Show();
        }

        private void UserUpdateBtn(object sender, RoutedEventArgs e)
        {
            UserUpdatePage userUpdatePage = new UserUpdatePage(_user.Id);

            //PagesNavigation.Navigate(new System.Uri("Pages/UserUpdatePage.xaml", UriKind.RelativeOrAbsolute));
        }

    }
}
