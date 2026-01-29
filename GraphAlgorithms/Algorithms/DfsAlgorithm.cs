using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms.Algorithms
{
    class DfsAlgorithm
    {
       private int n; // liczba wierzchołków
       private int[,] A; // Macierz sąsiedztwa
       private bool[] visited;// Tablica odwiedzin

      public DfsAlgorithm(int vertices)
      {
        n = vertices;
        A = new int[n, n];
        visited = new bool[n];
      }


      //Dodawanie krawędzi v1 -> v2
      public void AddEdge(int v1, int v2)
      {
        A[v1, v2] = 1;
      }
    // Publiczna metoda uruchamiająca algorytm
      public void RunDfs(int startVertex)
      {
        for(int i = 0; i < n; i++)
        {
        Console.WriteLine();
        Dfs(startVertex);
        Console.WriteLine();
        }
      }

    //Prywatna rekurencyjna procedura DFS
      private void Dfs(int v)
      {
      visited[v] = true;
      Console.WriteLine($"{v,3}");
      for(int i = 0; i < n; i++)
      {
        if (A[v, i] == 1 && !visited[i])
        {
          Dfs(i);
        }
      }
      }
    }
}
