using System.Collections.Generic;
using System.Text;

namespace GraphAlgorithms.Algorithms
{
  public static class BfsAlgorithm
  {
    public static string Run(List<int>[] graph, int start)
    {
      int n = graph.Length;
      bool[] visited = new bool[n];
      Queue<int> queue = new Queue<int>();
      StringBuilder result = new StringBuilder();

      queue.Enqueue(start);
      visited[start] = true;

      while (queue.Count > 0)
      {
        int v = queue.Dequeue();
        result.Append(v).Append(" ");

        foreach (int u in graph[v])
        {
          if (!visited[u])
          {
            visited[u] = true;
            queue.Enqueue(u);
          }
        }
      }

      return result.ToString().Trim();
    }
  }
}
