using GraphAlgorithms.Algorithms;
using GraphAlgorithms.Drawing;
using Microsoft.Maui.Graphics;

namespace GraphAlgorithms.Views;

public partial class DFS : ContentPage
{
  private DfsStepper? dfs;
  private TreeDrawable? drawable;
  private List<int>[]? graph;

  public DFS()
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

    dfs = new DfsStepper(graph, 0);

    drawable = new TreeDrawable();
    TreeView.Drawable = drawable;

    OutputLabel.Text = "";
    UpdateUI();
  }

  private void UpdateUI()
  {
    if (dfs == null || drawable == null)
      return;

    drawable.Parent = dfs.Parent;
    drawable.Level = dfs.Level;
    drawable.Highlight = dfs.CurrentVertex;

    TreeView.Invalidate();
    OutputLabel.Text = dfs.Output.ToString();
  }

  private void OnResetClicked(object sender, EventArgs e)
  {
    ResetAlgorithm();
  }

  private void OnNextStepClicked(object sender, EventArgs e)
  {
    if (dfs == null)
      return;

    if (!dfs.Step())
    {
      DisplayAlert("DFS", "Algorytm zakoñczony", "OK");
      return;
    }

    UpdateUI();
  }
}
