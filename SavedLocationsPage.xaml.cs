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
            // The map view's location display is initially null, so check for a location display property change before enabling it.
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
}

