using Esri.ArcGISRuntime.UI;
using System.ComponentModel;
using TakPhone.Models;

namespace TakPhone.Views;

public partial class SavedLocationsPage : ContentPage
{
    public SavedLocationsPage()
    {
        InitializeComponent();
        BindingContext = new SavedLocationsViewModel();

        MainMapView.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
        {
            if (e.PropertyName == nameof(LocationDisplay))
            {
                _ = DisplayDeviceLocationAsync();
            }
        };
    }

    private async Task DisplayDeviceLocationAsync()
    {
        PermissionStatus status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        MainMapView.LocationDisplay.IsEnabled = status == PermissionStatus.Granted || status == PermissionStatus.Restricted;
        MainMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Recenter;
    }

    private async void SaveCurrentLocationToViewModel(object sender, EventArgs e)
    {
        var location = await Geolocation.GetLastKnownLocationAsync();
        if (location != null)
        {
            // Display an alert dialog with an input field
            string locationName = await DisplayPromptAsync("Save Location", "Enter location name:", initialValue: "", maxLength: 50, keyboard: Keyboard.Text);

            if (!string.IsNullOrWhiteSpace(locationName))
            {
                double latitude = location.Latitude;
                double longitude = location.Longitude;

                var viewModel = BindingContext as SavedLocationsViewModel;
                viewModel?.SaveCurrentLocation(latitude, longitude, locationName);
            }
        }
    }


}

