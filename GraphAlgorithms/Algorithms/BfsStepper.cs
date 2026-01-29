using System.Collections.Generic;
using System.Text;

namespace GraphAlgorithms.Algorithms
{
  public class BfsStepper
  {
    private readonly List<int>[] graph;
    private readonly bool[] visited;
    private readonly Queue<int> queue;

    public int[] Parent { get; }
    public int[] Level { get; }

    public StringBuilder Output { get; } = new();
    public int? CurrentVertex { get; private set; }

    public BfsStepper(List<int>[] graph, int start)
    {
      this.graph = graph;
      visited = new bool[graph.Length];
      queue = new Queue<int>();

      Parent = new int[graph.Length];
      Level = new int[graph.Length];
      for (int i = 0; i < graph.Length; i++)
        Parent[i] = -1;

      queue.Enqueue(start);
      visited[start] = true;
      Level[start] = 0;
    }

    public bool Step()
    {
      if (queue.Count == 0)
        return false;

      int v = queue.Dequeue();
      CurrentVertex = v;
      Output.Append(v).Append(" ");

      foreach (int u in graph[v])
      {
        if (!visited[u])
        {
          visited[u] = true;
          Parent[u] = v;
          Level[u] = Level[v] + 1;
          queue.Enqueue(u);
        }
      }
      return true;
    }

    public string QueueState() => string.Join(" ", queue);
  }
}
