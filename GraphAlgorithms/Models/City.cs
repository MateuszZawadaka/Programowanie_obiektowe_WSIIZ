using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms.Models
{
    public class City
    {

      public string? Name { get; set; }
      public double X { get; set; }
      public double Y { get; set; }

      public City() { }

      public City(string name, double x, double y)
      {
        Name = name;
        X = x;
        Y = y;
      }
  }
}
