using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Ex3
    {
      private int[] notDisplayedNumbers = {2, 6, 9, 15, 19};


      public void show()
      {
        for(int i = 20; i >=0; i--)
        {
          bool skip = false;
          foreach(int num in notDisplayedNumbers)
          {
            if(i == num)
            {
              skip = true;
              break;
            }
          }
        if (skip)
        {
          continue;

        }
        Console.WriteLine(i);
        }
      }
    }
}
