using System.Net.WebSockets;
using System.Text;

namespace ABMCalibrationApp.Services;

public class WebSocketService
{
  private ClientWebSocket? _webSocket;
  private CancellationTokenSource? _cts;

  private const string ServerUrl = "ws://10.42.0.1:8765";

  public bool IsConnected =>
      _webSocket != null &&
      _webSocket.State == WebSocketState.Open;

  public async Task ConnectAsync()
  {
    _webSocket = new ClientWebSocket();
    _cts = new CancellationTokenSource();
    await _webSocket.ConnectAsync(new Uri(ServerUrl), _cts.Token);
  }

  public async Task DisconnectAsync()
  {
    if (_webSocket != null && _webSocket.State == WebSocketState.Open)
    {
      await _webSocket.CloseAsync(
          WebSocketCloseStatus.NormalClosure,
          "Disconnect",
          CancellationToken.None);
    }
  }

  public async Task SendAsync(string message)
  {
    if (!IsConnected) return;

    var bytes = Encoding.UTF8.GetBytes(message);
    await _webSocket!.SendAsync(
        bytes,
        WebSocketMessageType.Text,
        true,
        CancellationToken.None);
  }
}