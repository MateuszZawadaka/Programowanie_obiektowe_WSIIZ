using System;
using System.Collections.Generic;

namespace GraphAlgorithms.Algorithms
{
  public class TravellingSalesman
  {
    private readonly int[,] graph;
    private readonly int n;

    public int BestCost { get; private set; } = int.MaxValue;
    public List<int> BestPath { get; private set; } = new();

    public TravellingSalesman(int[,] graph)
    {
      this.graph = graph;
      n = graph.GetLength(0);
    }

    /// <summary>
    /// Uruchamia algorytm komiwojażera (brute force)
    /// </summary>
    public void Solve(int start = 0)
    {
      bool[] visited = new bool[n];
      List<int> path = new();

      visited[start] = true;
      path.Add(start);

      DFS(start, start, visited, path, 0);
    }

    /// <summary>
    /// Rekurencyjne przeszukiwanie wszystkich cykli Hamiltona
    /// </summary>
    private void DFS(
        int current,
        int start,
        bool[] visited,
        List<int> path,
        int cost)
    {
      if (path.Count == n)
      {
        // powrót do wierzchołka startowego
        int totalCost = cost + graph[current, start];
        if (totalCost < BestCost)
        {
          BestCost = totalCost;
          BestPath = new List<int>(path);
          BestPath.Add(start);
        }
        return;
      }

      for (int next = 0; next < n; next++)
      {
        if (!visited[next] && graph[current, next] > 0)
        {
          visited[next] = true;
          path.Add(next);

          DFS(
              next,
              start,
              visited,
              path,
              cost + graph[current, next]
          );

          // cofanie (backtracking)
          visited[next] = false;
          path.RemoveAt(path.Count - 1);
        }
      }
    }
  }
}
