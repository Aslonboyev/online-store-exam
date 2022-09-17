using OnlineStore.Domain.Entities.Users;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
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
            _id = id;

            _userService = new UserService();

            InitializeComponent();

            //ButtonsStackPanelUI.Children.Add(new RadioButton() { Content = "New birnarsa" });

            FirstnameCtn.Content = firstname;
            rdHome_Click(null, null);
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

        private async void UserBtn(object sender, RoutedEventArgs e)
        {
            var result = await _userService.GetAsync(p => p.Id == _id);
            UserDetailData = result.Data;

            // userDetail.Show();
            PagesNavigation.Navigate(new System.Uri("Pages/UserPages/UserDetailPage.xaml", UriKind.RelativeOrAbsolute), result.Data);

            //this.Close();
        }

        private void rdSounds_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdContacts_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/AddProductPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/AddCategoryPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/AddLocationPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/AddUserPage.xaml", UriKind.RelativeOrAbsolute));

        }

        private void home_Loaded(object sender, RoutedEventArgs e)
        {
            if(MainWindow.IsAdmin is true)
            {
                AddProduct.Visibility = Visibility.Visible;
                AddCategory.Visibility = Visibility.Visible;
                AddLocation.Visibility = Visibility.Visible;
                AddUser.Visibility = Visibility.Visible;
            }
        }
    }
}
