using GraphAlgorithms.Algorithms;
using GraphAlgorithms.Drawing;
using Microsoft.Maui.Graphics;


namespace GraphAlgorithms.Views;

public partial class BFS : ContentPage
{
  private BfsStepper? bfs;
  private TreeDrawable? drawable;
  private List<int>[]? graph;


  public BFS()
  {
    InitializeComponent();
    ResetAlgorithm();
  }

  private void ResetAlgorithm()
  {
    int n = 6;
    graph = new List<int>[n];

    for (int i = 0; i < n; i++)
      graph[i] = new List<int>();

    graph[0].Add(1);
    graph[0].Add(2);
    graph[1].Add(3);
    graph[1].Add(4);
    graph[2].Add(5);

    bfs = new BfsStepper(graph, 0);

    drawable = new TreeDrawable();
    TreeView.Drawable = drawable;

    OutputLabel.Text = "";
    UpdateUI();
  }

  private void UpdateUI()
  {
    if (bfs == null || drawable == null)
      return;

    drawable.Parent = bfs.Parent;
    drawable.Level = bfs.Level;
    drawable.Highlight = bfs.CurrentVertex;

    TreeView.Invalidate();
    OutputLabel.Text = bfs.Output.ToString();
  }

  private void OnResetClicked(object sender, EventArgs e)
  {
    ResetAlgorithm();
  }

  private void OnNextStepClicked(object sender, EventArgs e)
  {
    if (bfs == null)
    {
      return;
    }
      
    if (!bfs.Step())
    {
      DisplayAlert("BFS", "Algorytm zakoñczony", "OK");
      return;
    }
    UpdateUI();
  }
}
