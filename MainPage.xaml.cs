using System.Text.Json;

namespace TakPhone;

public partial class MainPage : ContentPage{
	public MainPage()
	{
		InitializeComponent();


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

