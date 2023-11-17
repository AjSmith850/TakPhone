namespace TakPhone;
using Microsoft.Maui.Graphics;


public partial class MainPage : ContentPage{
	public MainPage()
	{
        // CheckAndRequestLocationPermission();

        InitializeComponent();

        SizeChanged += OnSizeChanged;

        Compass.ReadingChanged += (s, e) =>
        {
            var heading = e.Reading.HeadingMagneticNorth;

            string cardinalDirection = CalculateCardinalDirection(heading);

            directionLabel.Text = "Cardinal Direction: " + cardinalDirection;
        };

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

    //public async Task GetLocationPermissionAsync()
    //{
    //    var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

    //    if (status != PermissionStatus.Granted)
    //    {
    //        status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
    //    }

    //    if (status == PermissionStatus.Granted)
    //    {
    //        // You have the permission
    //        // TODO: Access the user's location here
    //    }
    //    else if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.Android)
    //    {
    //        // On Android 
    //        await Shell.Current.DisplayAlert(
    //            "Location Permission", "Location permission is required for app functionallity",
    //            "OK");
    //    }
    //}

    //private async void CheckAndRequestLocationPermission()
    //{
    //    await GetLocationPermissionAsync();
    //}


    private void OnSizeChanged(object sender, EventArgs e)
    {
        var width = DeviceDisplay.MainDisplayInfo.Width;
        var height = DeviceDisplay.MainDisplayInfo.Height;
        
    }

    /* //got rid of grid coords overlay button
    private async void ToggleGridCoords(object sender, EventArgs e)
    {
        gridCoordinatesFrame.IsVisible = !gridCoordinatesFrame.IsVisible;
        gridCoordinatesLabel.IsVisible = !gridCoordinatesLabel.IsVisible;


        if (gridCoordinatesLabel.IsVisible)
        {
            var location = await Geolocation.GetLastKnownLocationAsync();

            if (location != null)
            {
                double latitude = location.Latitude;
                double longitude = location.Longitude;
                gridCoordinatesLabel.Text = $"Grid Coordinates: ({latitude}, {longitude})";
            }
            else
            {
                gridCoordinatesLabel.Text = "Unable to retrieve location.";
            }
        }
    }
    */


    // RestService Class example from: https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/rest

}

