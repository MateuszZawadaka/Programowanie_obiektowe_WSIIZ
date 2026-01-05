using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class BankAccount : Person
    {
     public decimal Saldo { get; private set; }


      public BankAccount(string name, string surname, int age, decimal saldo) : base(name, surname, age)
      {
        this.Saldo = saldo;
      }

      public void Wplata(decimal kwota)
      {
        if(kwota < 0)
        {
          Console.WriteLine("Nie można wpłacić mniej niż 0 zł");
          return;
        }
        Saldo += kwota;
        Console.WriteLine($"Stan konta po wpłacie: {Saldo}");
      }

      public void Wyplata(decimal kwota)
      {
        if(kwota > Saldo)
        {
          Console.WriteLine("Brak wystarczających środków na koncie");

        }
        else
        {
          Saldo -= kwota;
          Console.WriteLine($"Wypłacono: {kwota}. Pozostało na koncie {Saldo}");
        }
      }


    }
}
