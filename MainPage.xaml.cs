namespace TakPhone;
using Microsoft.Maui.Graphics;


public partial class MainPage : ContentPage{
	public MainPage()
	{
        // CheckAndRequestLocationPermission();

        InitializeComponent();

        SizeChanged += OnSizeChanged;
        
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

        if (width > height)
        {
            gridCoordinatesFrame.IsVisible = !gridCoordinatesFrame.IsVisible;
            gridCoordinatesFrame.IsVisible = !gridCoordinatesFrame.IsVisible;

            AbsoluteLayout.SetLayoutBounds(gridCoordinatesFrame, new Rect(0.98, 0.8, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }
        else
        {
            AbsoluteLayout.SetLayoutBounds(gridCoordinatesFrame, new Rect(0.98, 0.87, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }

        gridCoordinatesFrame.ForceLayout();
    }

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

    private void ToggleFlyout(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }

    // RestService Class example from: https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/rest

}

