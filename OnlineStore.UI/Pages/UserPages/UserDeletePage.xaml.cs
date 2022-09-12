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
        public UserDeletePage()
        {
            InitializeComponent();
        }

        private void UserDeletedBtn(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();

            registerPage.Show();

            this.Close();
        }
    }
}
