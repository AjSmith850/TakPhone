namespace TakPhone;

public partial class MainPage : ContentPage{
	public MainPage()
	{
		InitializeComponent();

        SizeChanged += OnSizeChanged;
    }

    private void OnSizeChanged(object sender, EventArgs e)
    {
        var width = DeviceDisplay.MainDisplayInfo.Width;
        var height = DeviceDisplay.MainDisplayInfo.Height;

        if (width > height)
        {
            Shell.SetNavBarIsVisible(this, false);
            Shell.SetFlyoutBehavior(this, FlyoutBehavior.Flyout);
        } 
        else
        {
            Shell.SetNavBarIsVisible(this, false);
            Shell.SetFlyoutBehavior(this, FlyoutBehavior.Flyout);
        }
    }

    private async void ToggleGridCoords(object sender, EventArgs e)
    {
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

    // RestService Class example from: https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/rest

    /*    public class RestService
        {
            HttpClient _client;
            JsonSerializerOptions _serializerOptions;

            public List<TodoItem> Items { get; private set; }

            public RestService()
            {
                _client = new HttpClient();
                _serializerOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
            }

        }*/
}

