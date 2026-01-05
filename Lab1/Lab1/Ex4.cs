using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Ex4
    {
    private int number;
    public void run()
    {
      while (true)
      {
        Console.WriteLine("Wpropwadź liczbę całkowitą");
        number = int.Parse(Console.ReadLine());

        if(number < 0)
        {
          Console.WriteLine("Liczba mniejsza od zera");
          break;
        }
      }
    }
    }
}
