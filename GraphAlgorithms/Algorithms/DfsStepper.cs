using System.Collections.Generic;
using System.Text;

namespace GraphAlgorithms.Algorithms
{
  public class DfsStepper
  {
    private readonly List<int>[] graph;
    private readonly bool[] visited;
    private readonly Stack<int> stack;

    public int[] Parent { get; }
    public int[] Level { get; }

    public StringBuilder Output { get; } = new();
    public int? CurrentVertex { get; private set; }

    public DfsStepper(List<int>[] graph, int start)
    {
      this.graph = graph;
      visited = new bool[graph.Length];
      stack = new Stack<int>();

      Parent = new int[graph.Length];
      Level = new int[graph.Length];

      for (int i = 0; i < graph.Length; i++)
        Parent[i] = -1;

      stack.Push(start);
      visited[start] = true;
      Level[start] = 0;
    }

    public bool Step()
    {
      if (stack.Count == 0)
        return false;

      int v = stack.Pop();
      CurrentVertex = v;
      Output.Append(v).Append(" ");

      for (int i = graph[v].Count - 1; i >= 0; i--)
      {
        int u = graph[v][i];
        if (!visited[u])
        {
          visited[u] = true;
          Parent[u] = v;
          Level[u] = Level[v] + 1;
          stack.Push(u);
        }
      }
      return true;
    }

    public string StackState() => string.Join(" ", stack);
  }
}
