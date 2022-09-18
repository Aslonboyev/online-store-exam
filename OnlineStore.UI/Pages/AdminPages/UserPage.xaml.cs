﻿using OnlineStore.Domain.Entities.Products;
using OnlineStore.Domain.Entities.Users;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using OnlineStore.UI.Pages.AdminPages.AllComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineStore.UI.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private readonly IUserService _userService;
        private Thread thread;

        public UserPage()
        {
            InitializeComponent();

            _userService = new UserService();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            thread = new Thread(async () =>
            {
                Dispatcher.Invoke(() => UserListCtn.Children.Clear());

                var response = await _userService.GetAllAsync();
                MainWindow.AllUsers = response.Data.ToList();

                await LoadUsers(MainWindow.AllUsers);
            });

            thread.Start();
        }

        private async Task LoadUsers(List<User> users)
        {
            foreach (var user in users)
            {
                await this.Dispatcher.InvokeAsync(() =>
                {
                    UserItem userItem = new UserItem();
                    userItem.FullnameCtn.Content = user.FirstName + " " + user.LastName;
                    userItem.UsernameCtn.Content = user.Username;
                    userItem.PhoneCtn.Content = user.Phone;
                    userItem.EmailCtn.Content = user.Email;

                    UserListCtn.Children.Add(userItem);
                });
            }
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
