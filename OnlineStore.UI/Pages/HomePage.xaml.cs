using System.Windows.Controls;

namespace OnlineStore.UI.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            CartName.Text = "";
        }

        private void CartBtn(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void SearchBar_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 3)
            {

            }
        }
    }
}
