using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Ex1
    {
    public float A { get; set; }
    public float B { get; set; }
    public float C { get; set; }


    private float delta()
    {
      return (B * B) - (4 * A * C);
    }

    public void run()
    {
      Console.WriteLine("START ZADANIA 1");
      Console.WriteLine("Podaj współczynnik A: ");
      A = float.Parse(Console.ReadLine());

      Console.WriteLine("Podaj współczynnik B: ");
      B = float.Parse(Console.ReadLine());

      Console.WriteLine("Podaj współczynnik C: ");
      C = float.Parse(Console.ReadLine());

      Console.WriteLine("OBLICZANIE DELTY");
      float delta = this.delta();
      Console.WriteLine($"Wynik delty: {delta}");

    }

  }
}
