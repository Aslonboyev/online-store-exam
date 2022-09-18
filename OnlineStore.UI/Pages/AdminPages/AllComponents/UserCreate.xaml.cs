using OnlineStore.Service.DTOs.UserDTOs;
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

namespace OnlineStore.UI.Pages.AdminPages.AllComponents
{
    /// <summary>
    /// Interaction logic for UserCreate.xaml
    /// </summary>
    public partial class UserCreate : Window
    {
        private readonly IUserService _userService;

        public UserCreate()
        {
            InitializeComponent();
         
            _userService = new UserService();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

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

                    PagesNavigation.Navigate(new System.Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));

                    this.Close();
                }
                else
                    MessageBox.Show("Check your details. \nYour details are already taken or wrong!");
            }
        }
    }
}
