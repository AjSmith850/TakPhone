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



    private void OnSizeChanged(object sender, EventArgs e)
    {
        var width = DeviceDisplay.MainDisplayInfo.Width;
        var height = DeviceDisplay.MainDisplayInfo.Height;

        this.Dispatcher.Dispatch(() =>
        {
            if (width > height)
            {
                AbsoluteLayout.SetLayoutBounds(gridCoordButton, new Rect(0.98, 0.8, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                AbsoluteLayout.SetLayoutBounds(cardDirButton, new Rect(0.98, 0.6, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            }
            else
            {
                AbsoluteLayout.SetLayoutBounds(gridCoordButton, new Rect(0.98, 0.88, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                AbsoluteLayout.SetLayoutBounds(cardDirButton, new Rect(0.98, 0.8, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            }
        });


    }

    private void UpdateCardinalDirection(object sender, EventArgs e)
    {
        Compass.ReadingChanged += OnCompassReadingChanged;
        Compass.Start(SensorSpeed.UI);
    }

    private void OnCompassReadingChanged(object sender, CompassChangedEventArgs e)
    {
        var heading = e.Reading.HeadingMagneticNorth;
        string cardinalDirection = CalculateCardinalDirection(heading);
        cardDirButton.Text = cardinalDirection;
        cardDirButton.FontSize = 30;
        Compass.Stop();
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


    private async void ToggleGridCoords(object sender, EventArgs e)
    {

        var location = await Geolocation.GetLastKnownLocationAsync();

        double latitude = location.Latitude;
        double longitude = location.Longitude;

        // Format to 5 decimals
        string formattedLatitude = latitude.ToString("F5");
        string formattedLongitude = longitude.ToString("F5");

        gridCoordButton.Text = $"({formattedLatitude}, {formattedLongitude})";

    }

    private void ToggleFlyout(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }
    



}

