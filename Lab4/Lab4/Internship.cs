using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Internship : IContract
    {
    private decimal StawkaMiesieczna;

    public Internship(decimal stawkaMiesieczna)
    {
      StawkaMiesieczna = stawkaMiesieczna;
    }

    public decimal Salary()
    {
      return StawkaMiesieczna;
    }
    public override string ToString()
    {
      string ret = $"Stawka miesieczna: {Salary()}";
      return ret;
    }
  }
}
