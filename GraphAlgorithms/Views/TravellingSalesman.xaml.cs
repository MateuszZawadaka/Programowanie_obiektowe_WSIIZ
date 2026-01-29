using GraphAlgorithms.Algorithms;
using System.Text.Json;
using GraphAlgorithms.Models;

namespace GraphAlgorithms.Views;

public partial class TravellingSalesman : ContentPage
{
  private TspStepper? tsp;
  private List<City>? cities;
  private int[,]? distances;

  public TravellingSalesman()
  {
    InitializeComponent();
    LoadConfiguration();
  }

  private void LoadConfiguration()
  {
    if (Preferences.Default.ContainsKey("tsp_cities"))
    {
      string json = Preferences.Default.Get("tsp_cities", "");
      cities = JsonSerializer.Deserialize<List<City>>(json);

      if (cities != null && cities.Count > 0)
      {
        distances = CalculateDistanceMatrix(cities);
        Reset();
      }
      else
      {
        UseDefaultData();
      }
    }
    else
    {
      UseDefaultData();
    }
  }

  private int[,] CalculateDistanceMatrix(List<City> cityList)
  {
    int n = cityList.Count;
    var matrix = new int[n, n];

    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < n; j++)
      {
        if (i == j)
        {
          matrix[i, j] = 0;
        }
        else
        {
          double dx = cityList[j].X - cityList[i].X;
          double dy = cityList[j].Y - cityList[i].Y;
          matrix[i, j] = (int)Math.Sqrt(dx * dx + dy * dy);
        }
      }
    }
    return matrix;
  }

  private void UseDefaultData()
  {
    string[] defaultCities = { "Kraków", "Warszawa", "Gdańsk", "Wrocław", "Poznań" };

    cities = new List<City>();
    for (int i = 0; i < defaultCities.Length; i++)
    {
      cities.Add(new City(defaultCities[i], 100 + i * 50, 100 + i * 30));
    }

    distances = new int[,]
    {
            {  0,  295, 485, 270, 335 },
            { 295,   0, 340, 355, 310 },
            { 485, 340,   0, 470, 300 },
            { 270, 355, 470,   0, 180 },
            { 335, 310, 300, 180,   0 }
    };
  }

  private void Reset()
  {
    if (distances == null || distances.GetLength(0) < 2)
    {
      DisplayAlert("Błąd", "Za mało miast do uruchomienia TSP", "OK");
      return;
    }

    tsp = new TspStepper(distances, start: 0);
    UpdateUI();
  }

  private void UpdateUI()
  {
    if (tsp == null || cities == null)
      return;

    if (tsp.CurrentPath.Count > 0)
    {
      CurrentPathLabel.Text = string.Join(" → ",
          tsp.CurrentPath.Select(i => cities[i].Name));
      CurrentCostLabel.Text = $"{tsp.CurrentCost} jednostek";
    }

    if (tsp.BestPath.Count > 0)
    {
      BestPathLabel.Text = string.Join(" → ",
          tsp.BestPath.Select(i => cities[i].Name));
      BestCostLabel.Text = $"{tsp.BestCost} jednostek";
    }
    CityCountLabel.Text = $"Liczba miast: {cities.Count}";
  }

  private void OnNextStepClicked(object sender, EventArgs e)
  {
    if (tsp == null || !tsp.Step())
    {
      DisplayAlert("TSP", "Algorytm zakończony", "OK");
      return;
    }
    UpdateUI();
  }

  private void OnResetClicked(object sender, EventArgs e)
  {
    Reset();
  }

  private async void OnConfigureClicked(object sender, EventArgs e)
  {
    await Navigation.PushAsync(new TSPConfig());
  }
  private void OnRefreshClicked(object sender, EventArgs e)
  {
    LoadConfiguration();
    Reset();
    DisplayAlert("Odświeżono", "Wczytano aktualną konfigurację", "OK");
  }
}