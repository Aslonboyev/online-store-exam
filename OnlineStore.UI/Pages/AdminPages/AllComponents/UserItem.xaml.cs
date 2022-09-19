using OnlineStore.Domain.Entities.Users;
using OnlineStore.UI.Pages.UserPages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineStore.UI.Pages.AdminPages.AllComponents
{
    /// <summary>
    /// Interaction logic for UserItem.xaml
    /// </summary>
    public partial class UserItem : UserControl
    {
        public UserItem()
        {
            InitializeComponent();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            UserDeletePage userDeletePage = new UserDeletePage(long.Parse(button.Uid[2..]));

            userDeletePage.Show();
        }
    }
}
