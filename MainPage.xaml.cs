namespace TakPhone;

using Microsoft.Maui.Graphics;

using Esri.ArcGISRuntime.UI;
using System.ComponentModel;


public partial class MainPage : ContentPage{
	public MainPage()
	{
        // CheckAndRequestLocationPermission();

        InitializeComponent();

        MainMapView.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
        {
            // The map view's location display is initially null, so check for a location display property change before enabling it.
            if (e.PropertyName == nameof(LocationDisplay))
            {
                _ = DisplayDeviceLocationAsync();
            }
        };

        SizeChanged += OnSizeChanged;


    }

    private async Task DisplayDeviceLocationAsync()
    {
        PermissionStatus status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

        MainMapView.LocationDisplay.IsEnabled = status == PermissionStatus.Granted || status == PermissionStatus.Restricted;
        MainMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Recenter;
    }

    private string CalculateCardinalDirection(double heading)
    {
        heading = (heading + 360) % 360;

        if (heading >= 337.5 || heading < 22.5)
            return "N";
        else if (heading >= 22.5 && heading < 67.5)
            return "NE";
        else if (heading >= 67.5 && heading < 112.5)
            return "E";
        else if (heading >= 112.5 && heading < 157.5)
            return "SE";
        else if (heading >= 157.5 && heading < 202.5)
            return "S";
        else if (heading >= 202.5 && heading < 247.5)
            return "SW";
        else if (heading >= 247.5 && heading < 292.5)
            return "W";
        else if (heading >= 292.5 && heading < 337.5)
            return "NW";

        return "Unknown";
    }



    private void OnSizeChanged(object sender, EventArgs e)
    {
        var width = DeviceDisplay.MainDisplayInfo.Width;
        var height = DeviceDisplay.MainDisplayInfo.Height;
        
    }

    private void UpdateCardinalDirection(object sender, EventArgs e)
    {
        Compass.ReadingChanged += (s, e) =>
        {
            var heading = e.Reading.HeadingMagneticNorth;

            string cardinalDirection = CalculateCardinalDirection(heading);

            cardDirButton.Text = "Cardinal Direction: " + cardinalDirection;
        };
    }

    private void UpdateGridCoordinates(object sender, EventArgs e)
    {
        Task.Run(async () =>
        {
            var location = await Geolocation.GetLastKnownLocationAsync();

            Dispatcher.Dispatch(() =>
            {
                if (location != null)
                {
                    double latitude = location.Latitude;
                    double longitude = location.Longitude;
                    gridCoordButton.Text = $"Grid Coordinates: ({latitude}, {longitude})";
                }
                else
                {
                    gridCoordButton.Text = "Unable to retrieve location.";
                }
            });
        });
    }


}

