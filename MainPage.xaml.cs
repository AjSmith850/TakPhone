namespace TakPhone;
using Microsoft.Maui.Graphics;

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

