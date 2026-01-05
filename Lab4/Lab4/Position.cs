using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
  class Position : IContract
  {
    private decimal MonthlyRate;
    private int Overtime;

    public Position(decimal monthlyRate, int overtime)
    {
      MonthlyRate = monthlyRate;
      Overtime = overtime;
    }

    public decimal Salary()
    {
      return MonthlyRate + Overtime * (MonthlyRate / 60m);
    }

    public override string ToString()
    {
      string ret = $"Rodzaj umowy: etat. Stawka miesięczna: {Salary()}";
      return ret;
    }
  }
}
