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
        private readonly IUserService _userService;

        public MainPage(long id, string firstname)
        {
            _id = id;

            _userService = new UserService();

            InitializeComponent();

            //ButtonsStackPanelUI.Children.Add(new RadioButton() { Content = "New birnarsa" });

            FirstnameCtn.Content = firstname;
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

        private void rdSounds_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/SoundsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdNotes_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/NotesPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdPayment_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/PaymentPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void UserBtn(object sender, RoutedEventArgs e)
        {
            var result = await _userService.GetAsync(p => p.Id == _id);

            UserDetailPage userDetail = new UserDetailPage(result.Data);

            userDetail.Show();

            this.Close();
        }
    }
}
