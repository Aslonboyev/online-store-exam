﻿using OnlineStore.Service.DTOs.UserDTOs;
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

namespace OnlineStore.UI.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        private readonly IUserService _userService;
        private readonly MainWindow _mainWindow;

        public RegisterPage()
        {
            _mainWindow = new MainWindow();
            
            _userService = new UserService();

            InitializeComponent();
        }

        private async void SignUpBtn(object sender, RoutedEventArgs e)
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

                var result = await _userService.CreateAsync(userCreationDTO);

                if (result.Data is not null)
                {
                    _mainWindow.Show();
                    this.Close();
                }
            }
        }

        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            _mainWindow.Show();
            this.Close();
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
