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

namespace OnlineStore.UI.Pages.HomePages
{
    /// <summary>
    /// Interaction logic for CategoryItem.xaml
    /// </summary>
    public partial class CategoryItem : UserControl
    {
        public CategoryItem()
        {
            InitializeComponent();
        }

        private void CategoryNameCtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

        }
    }
}
