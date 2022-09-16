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

namespace OnlineStore.UI.Pages.HomePages
{
    /// <summary>
    /// Interaction logic for ChooseProduct.xaml
    /// </summary>
    public partial class ChooseProduct : Window
    {
        private readonly long _id;
        private readonly IProductService productService;

        public ChooseProduct(long id)
        {
            InitializeComponent();
            
            productService = new ProductService();

            _id = id;
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var count = Convert.ToInt32(CountCtn.Content);
            CountCtn.Content = count + 1;
            var price = Convert.ToDecimal(PriceCtn.Content) / count;
            PriceCtn.Content = price * (count + 1);
        }

        private void LowBtn_Click(object sender, RoutedEventArgs e)
        {
            var count = Convert.ToInt32(CountCtn.Content);
            var price = Convert.ToDecimal(PriceCtn.Content) / count;

            if (count > 1)
            {
                count -= 1;
                CountCtn.Content = count;
                PriceCtn.Content = price * count;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ProductsBoxWIthId.Add(_id);
            MainWindow.ProductCount.Add(Convert.ToInt32(CountCtn.Content));
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await productService.GetAsync(p => p.Id == _id);

            CountCtn.Content = 1;
            PriceCtn.Content = result.Data.Price;
            ProductDescriptionCtn.Content = result.Data.Description;
            ProductNameCtn.Content = result.Data.Name;
        }
    }
}
