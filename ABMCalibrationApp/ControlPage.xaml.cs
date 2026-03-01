using ABMCalibrationApp.Services;

namespace ABMCalibrationApp;

public partial class ControlPage : ContentPage
{
  private readonly WebSocketService _ws;

  public ControlPage(WebSocketService ws)
  {
    InitializeComponent();
    _ws = ws;
  }

  private async void OnCommandClicked(object sender, EventArgs e)
  {
    if (sender is Button btn)
    {
      await _ws.SendAsync(btn.Text);
      await DisplayAlert("Wys³ano", btn.Text, "OK");
    }
  }
}
