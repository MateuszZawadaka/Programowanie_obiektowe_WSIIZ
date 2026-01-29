using System.Collections.Generic;

namespace GraphAlgorithms.Algorithms
{
  public class TspStepper
  {
    private readonly int[,] graph;
    private readonly int n;
    private readonly int start;

    private readonly Stack<State> stack = new();

    public List<int> CurrentPath { get; private set; } = new();
    public List<int> BestPath { get; private set; } = new();
    public int CurrentCost { get; private set; }
    public int BestCost { get; private set; } = int.MaxValue;

    private class State
    {
      public int City;
      public bool[] Visited;
      public List<int> Path;
      public int Cost;
    }

    public TspStepper(int[,] graph, int start)
    {
      this.graph = graph;
      this.start = start;
      n = graph.GetLength(0);

      var visited = new bool[n];
      visited[start] = true;

      stack.Push(new State
      {
        City = start,
        Visited = visited,
        Path = new List<int> { start },
        Cost = 0
      });
    }

    /// <summary>
    /// Wykonuje jeden krok algorytmu TSP
    /// </summary>
    public bool Step()
    {
      if (stack.Count == 0)
        return false;

      var state = stack.Pop();

      CurrentPath = state.Path;
      CurrentCost = state.Cost;

      if (state.Path.Count == n)
      {
        int totalCost = state.Cost + graph[state.City, start];

        if (totalCost < BestCost)
        {
          BestCost = totalCost;
          BestPath = new List<int>(state.Path) { start };
        }
        return true;
      }

      for (int next = n - 1; next >= 0; next--)
      {
        if (!state.Visited[next] && graph[state.City, next] > 0)
        {
          var visited = (bool[])state.Visited.Clone();
          visited[next] = true;

          var path = new List<int>(state.Path) { next };

          stack.Push(new State
          {
            City = next,
            Visited = visited,
            Path = path,
            Cost = state.Cost + graph[state.City, next]
          });
        }
      }
      return true;
    }
  }
}
