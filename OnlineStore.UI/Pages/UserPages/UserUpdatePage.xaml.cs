using OnlineStore.Service.DTOs.UserDTOs;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using System.Windows;

namespace OnlineStore.UI.Pages.UserPages
{
    /// <summary>
    /// Interaction logic for UserUpdatePage.xaml
    /// </summary>
    public partial class UserUpdatePage : Window
    {
        private readonly IUserService _userService;
        private readonly long _id;

        public UserUpdatePage(long id)
        {
            InitializeComponent();

            _id = id;

            _userService = new UserService();
        }

        private async void UserUpdatedBtn(object sender, RoutedEventArgs e)
        {
            if (passwordtxt.Password == repeatPasswordtxt.Password && usernametxt.Text is not null &&
                firstnametxt.Text is not null && lastnametxt.Text is not null && emailtxt.Text is not null &&
                phonetxt.Text is not null && passwordtxt.Password is not null)
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

                var result = await _userService.UpdateAsync(_id, userCreationDTO);

                if (result is not null)
                {
                    MainPage mainPage = new MainPage(_id, userCreationDTO.FirstName);

                    mainPage.Show();

                    this.Close();
                }
            }

            else
            {
                passwordtxt.Clear();
                repeatPasswordtxt.Clear();
            }
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
