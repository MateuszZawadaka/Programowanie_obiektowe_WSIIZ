using System.Net.WebSockets;

namespace ABMCalibrationApp;

public partial class MainPage : ContentPage
{
  private ClientWebSocket? _webSocket;
  private CancellationTokenSource? _cts;

  private const string ServerUrl = "ws://10.42.0.1:8765";

  public MainPage()
  {
    InitializeComponent();
  }

  private async void OnConnectClicked(object sender, EventArgs e)
  {
    try
    {
      _webSocket = new ClientWebSocket();
      _cts = new CancellationTokenSource();

      await _webSocket.ConnectAsync(new Uri(ServerUrl), _cts.Token);

      StatusLabel.Text = "CONNECTED";
      StatusLabel.TextColor = Colors.Green;
    }
    catch (Exception ex)
    {
      StatusLabel.Text = "ERROR";
      StatusLabel.TextColor = Colors.Red;
      await DisplayAlert("Błąd połączenia", ex.Message, "OK");
    }
  }

  private async void OnDisconnectClicked(object sender, EventArgs e)
  {
    try
    {
      if (_webSocket != null &&
          _webSocket.State == WebSocketState.Open)
      {
        await _webSocket.CloseAsync(
            WebSocketCloseStatus.NormalClosure,
            "Disconnect",
            CancellationToken.None);
      }

      StatusLabel.Text = "DISCONNECTED";
      StatusLabel.TextColor = Colors.Red;
    }
    catch (Exception ex)
    {
      await DisplayAlert("Błąd", ex.Message, "OK");
    }
  }
}