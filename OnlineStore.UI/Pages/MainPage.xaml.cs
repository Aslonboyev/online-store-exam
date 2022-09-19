using OnlineStore.Domain.Entities.Users;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using OnlineStore.UI.Pages.AdminPages;
using OnlineStore.UI.Pages.UserPages;
using System;
using System.Windows;

namespace OnlineStore.UI.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        private long _id;
        public static User UserDetailData;
        private readonly IUserService _userService;

        public MainPage(long id, string firstname)
        {
            InitializeComponent();
            _id = id;
            _userService = new UserService();
            FirstnameCtn.Content = firstname;
        }

        private void home_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.IsAdmin)
            {
                rdHome.Visibility = Visibility.Collapsed;
                UserBtn.Visibility = Visibility.Collapsed;
                rdAddCategory.Visibility = Visibility.Visible;
                rdAddLocation.Visibility = Visibility.Visible;
                rdAddProduct.Visibility = Visibility.Visible;
                rdAddUser.Visibility = Visibility.Visible;
                UserImageBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                rdHome_Click(null, null);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdContacts_Click(object sender, RoutedEventArgs e)
        {

            PagesNavigation.Navigate(new System.Uri("Pages/ContactPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdLocation_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/LocationPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.IsAdmin)
            {
                var result = await _userService.GetAsync(p => p.Id == _id);
                UserDetailData = result.Data;

                PagesNavigation.Navigate(new System.Uri("Pages/UserPages/UserDetailPage.xaml", UriKind.RelativeOrAbsolute), result.Data);
            }
            else
            {
                MessageBox.Show("You are admin not user!");
            }
        }

        private void rdSounds_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdContacts_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/ProductPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/CategoryPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/AdminLocationPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/UserPage.xaml", UriKind.RelativeOrAbsolute));

        }
    }
}
