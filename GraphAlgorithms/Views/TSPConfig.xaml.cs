using Microsoft.Maui.Controls.Shapes;
using System.Text.Json;
using Path = System.IO.Path;
using GraphAlgorithms.Models;

namespace GraphAlgorithms.Views;



public partial class TSPConfig : ContentPage
{
  private List<City> cities = new List<City>();
  private string filePath;

  public TSPConfig()
  {
    InitializeComponent();
    filePath = Path.Combine(FileSystem.AppDataDirectory, "tsp_config.json");

    LoadData();
  }

  private void OnAddCityClicked(object sender, EventArgs e)
  {
    int count = cities.Count + 1;
    string cityName = CityName.Text;
    double position_x = double.Parse(Position_x.Text);
    double position_y = double.Parse(Position_y.Text);
    cities.Add(new City($"Miasto:  {cityName}", position_x, position_y));
    UpdateList();
  }
  private async void OnSaveClicked(object sender, EventArgs e)
  {
    try
    {
      string json = JsonSerializer.Serialize(cities, new JsonSerializerOptions
      {
        WriteIndented = true
      });

      await File.WriteAllTextAsync(filePath, json);
      await DisplayAlert("Sukces", "Zapisano konfigurację", "OK");
    }
    catch (Exception ex)
    {
      await DisplayAlert("Błąd", $"Nie udało się zapisać: {ex.Message}", "OK");
    }
  }

  private void LoadData()
  {
    try
    {
      if (File.Exists(filePath))
      {
        string json = File.ReadAllText(filePath);
        cities = JsonSerializer.Deserialize<List<City>>(json) ?? new List<City>();
        UpdateList();
      }
    }
    catch
    {
    }
  }

  private void OnDeleteClicked(object sender, EventArgs e)
  {
    if (File.Exists(filePath))
    {
      File.Delete(filePath);
      cities.Clear();
      UpdateList();
      DisplayAlert("Usunięto", "Konfiguracja została usunięta", "OK");
    }
  }

  private async void OnRunTspClicked(object sender, EventArgs e)
  {
    if (cities.Count < 2)
    {
      await DisplayAlert("Błąd", "Dodaj co najmniej 2 miasta", "OK");
      return;
    }

    string json = JsonSerializer.Serialize(cities);
    Preferences.Default.Set("tsp_cities", json);

    await DisplayAlert("Gotowe", $"Przekazano {cities.Count} miast do TSP", "OK");
  }
  private async void OnShowPathClicked(object sender, EventArgs e)
  {
    string pathInfo = $"Plik zostanie zapisany w:\n{filePath}\n\n" +
                     $"Folder aplikacji:\n{FileSystem.AppDataDirectory}";

    await DisplayAlert("Ścieżka pliku", pathInfo, "OK");

    System.Diagnostics.Debug.WriteLine($"Ścieżka pliku: {filePath}");
  }
  private void UpdateList()
  {
    stackCities.Children.Clear();

    foreach (var city in cities)
    {
      var border = new Border
      {
        Margin = new Thickness(5),
        Padding = new Thickness(10),
        Stroke = Color.FromArgb("#CCCCCC"),
        StrokeThickness = 1,
        StrokeShape = new RoundRectangle { CornerRadius = 5 }
      };

      var stack = new StackLayout
      {
        Orientation = StackOrientation.Horizontal,
        Spacing = 10
      };

      stack.Children.Add(new Label { Text = "📍", FontSize = 16 });
      stack.Children.Add(new Label { Text = city.Name ?? "Brak nazwy", VerticalOptions = LayoutOptions.Center });
      stack.Children.Add(new Label { Text = $"X: {city.X}" });
      stack.Children.Add(new Label { Text = $"Y: {city.Y}" });

      border.Content = stack;
      stackCities.Children.Add(border);
    }
  }
}