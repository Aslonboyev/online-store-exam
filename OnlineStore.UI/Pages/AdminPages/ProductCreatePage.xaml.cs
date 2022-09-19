using OnlineStore.Domain.Entities.Categories;
using OnlineStore.Domain.Entities.Products;
using OnlineStore.Service.DTOs.ProductDTOs;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using OnlineStore.UI.Pages.AdminPages.AllComponents;
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

namespace OnlineStore.UI.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for ProductCreatePage.xaml
    /// </summary>
    public partial class ProductCreatePage : Page
    {
        private readonly IProductService productService;
        public static long CategoryId { get; set; }
        private string ImagePath { get; set; }
        public ProductCreatePage()
        {
            InitializeComponent();
            productService = new ProductService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(nametxt.Text is not null && quamtitytxt.Text is not null && pricetxt.Text is not null 
                && CategoryId != 0 && dscriptiontxt.Text is not null)
            {
                ProductCreationDTO productCreationDTO = new ProductCreationDTO()
                {
                    Name = nametxt.Text,
                    Description = dscriptiontxt.Text,
                    Quantity = decimal.Parse(quamtitytxt.Text),
                    CategoryId = CategoryId,
                    Price = decimal.Parse(pricetxt.Text),
                    ImagePath = ImagePath,
                };
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private async Task LoadCategories(IEnumerable<Category> categories)
        {
            foreach (var category in categories)
            {
                await this.Dispatcher.InvokeAsync(() =>
                {
                    ProductCategoryItem categoryItem = new ProductCategoryItem();
                    
                    categoryItem.CategoryNameCtn.Content = category.Name;
                    categoryItem.CategoryNameCtn.Uid = $"Id{category.Id}";

                    CategoryList.Children.Add(categoryItem);
                });
            }
        }

        private void PasspostImageBtn_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files(*.PNG,*.JPG;)|*.JPG;*.PNG",
                InitialDirectory = Environment.GetFolderPath
                (Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ImagePath = openFileDialog.FileName;

                ProductImage.Text = ImagePath.Split('\\').Last();
            }
        }

    }
}
