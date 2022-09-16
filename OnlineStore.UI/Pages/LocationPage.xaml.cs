using OnlineStore.Domain.Entities.Categories;
using OnlineStore.Domain.Entities.Locations;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;
using OnlineStore.UI.Pages.HomePages;
using OnlineStore.UI.Pages.LocationPages;
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

namespace OnlineStore.UI.Pages
{
    /// <summary>
    /// Interaction logic for LocationPage.xaml
    /// </summary>
    public partial class LocationPage : Page
    {
        private Thread thread;

        private readonly ILocationService locationService;

        private IEnumerable<Location> AllLocations;

        public LocationPage()
        {
            InitializeComponent();

            locationService = new LocationService();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            thread = new Thread(async () =>
            {
                Dispatcher.Invoke(() => LocationList.Children.Clear());

                var response = await locationService.GetAllAsync();
                AllLocations = response.Data;

                await LoadLocations(AllLocations);
            });

            thread.Start();
        }
        private async Task LoadLocations(IEnumerable<Location> locations)
        {
            foreach (var location in locations)
            {
                await this.Dispatcher.InvokeAsync(() =>
                {
                    LocationItem locationItem = new LocationItem();
                    locationItem.LocationNameCtn.Content = location.Name;
                    locationItem.LocationAddresCtn.Content = location.Address;
                    locationItem.LocationReagionCtn.Content = location.Region;
                    locationItem.LocationWorkTimeCtn.Content = location.WorkStartedAt.ToShortTimeString() + " - " + location.WorkEndedAt.ToShortTimeString();

                    LocationList.Children.Add(locationItem);
                });
            }
        }
    }
}
