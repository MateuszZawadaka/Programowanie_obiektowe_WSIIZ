using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Calculator
    {
      List<float> wyniki;
      Dictionary<int, List<string>> wynikOperacji;
        enum OperacjeMatematyczne
        {
          dodawanie = 1,
          odejmowanie = 2,
          mnozenie = 3,
          dzielenie = 4,
          pokazWyniki = 5,
          wyczyscListeWynikow = 6
        }

    public Calculator()
    {
      wyniki = new List<float> { };
    }
      public float Dodawanie()
      {
        try
        {
          float pierwszaLiczba = 0;
          float drugaLiczba = 0;
          Console.WriteLine("Podaj pierwsza liczbę do dodawania: ");
          pierwszaLiczba = float.Parse(Console.ReadLine());

          Console.WriteLine("Podaj druga liczbe do dodania");
          drugaLiczba = float.Parse(Console.ReadLine());
        float val = pierwszaLiczba + drugaLiczba;
        wyniki.Add(val);
        return val; 

        }
        catch(FormatException)
        {
          Console.WriteLine("Niepoprawny format danych");
          return 0;
        }

      
      }

    public float Odejmowanie()
    {
      try
      {
        float pierwszaLiczba = 0;
        float drugaLiczba = 0;
        Console.WriteLine("Podaj pierwsza liczbę do odejmowania: ");
        pierwszaLiczba = float.Parse(Console.ReadLine());

        Console.WriteLine("Podaj drugą liczbę");
        drugaLiczba = float.Parse(Console.ReadLine());
        float val = pierwszaLiczba - drugaLiczba;
        wyniki.Add(val);
        return val;
      }
      catch (FormatException)
      {
        Console.WriteLine("Niepoprawny format danych:");
        return 0;
      }
    }

    public float Mnozenie()
    {
      try
      {
        float pierwszaLiczba = 0;
        float drugaLiczba = 0;
        Console.WriteLine("Podaj pierwsza liczbę do mnozenia: ");
        pierwszaLiczba = float.Parse(Console.ReadLine());

        Console.WriteLine("Podaj drugą liczbę");
        drugaLiczba = float.Parse(Console.ReadLine());
        float val = pierwszaLiczba * drugaLiczba;
        wyniki.Add(val);
        return val;
      }
      catch (FormatException)
      {
        Console.WriteLine("Niepoprawny format danych:");
        return 0;
      }
    }
    public float Dzielenie()
    {
      try
      {
        float pierwszaLiczba = 0;
        float drugaLiczba = 0;
        Console.WriteLine("Podaj pierwsza liczbę do dzielenia: ");
        pierwszaLiczba = float.Parse(Console.ReadLine());

        Console.WriteLine("Podaj drugą liczbę");
        drugaLiczba = float.Parse(Console.ReadLine());
        float val = pierwszaLiczba / drugaLiczba;
        wyniki.Add(val);
        return val;
      }
      catch (FormatException)
      {
        Console.WriteLine("Niepoprawny format danych:");
        return 0;
      }
      catch (DivideByZeroException)
      {
        Console.WriteLine("Nie można dzielić przez zero");
        return 0;
      }
    }



    public void pokazwyniki()
    {
      Console.WriteLine("Lista wyników");
      foreach (var item in wyniki)
      {
        Console.WriteLine($"Wynik:{item}");
      }
    }

    public void wyczyscListeWynikow()
    {
      wyniki.Clear();
      Console.WriteLine("Lista wyników wyczyszczona");
    }


    public void run()
    {
      OperacjeMatematyczne Wybrana = 0;
      
      Console.WriteLine("Dostępne operacje: ");
      foreach(OperacjeMatematyczne operacja in Enum.GetValues(typeof(OperacjeMatematyczne)))
      {
        Console.WriteLine($"{Enum.GetName(operacja)}");
      }
      while (true)
      {
        try
        {
          Console.WriteLine("Wybierz Operacje matematyczną");
          Wybrana = (OperacjeMatematyczne)Enum.Parse(typeof(OperacjeMatematyczne), Console.ReadLine());

          switch (Wybrana)
          {
          case OperacjeMatematyczne.dodawanie:
            Console.WriteLine($"Wynik dodawania: {Dodawanie()}");
            break;

          case OperacjeMatematyczne.odejmowanie:
            Console.WriteLine($"Wynik odejmowania: {Odejmowanie()}");
            break;

          case OperacjeMatematyczne.mnozenie:
            Console.WriteLine($"Wynik mnożenia: {Mnozenie()}");
            break;

          case OperacjeMatematyczne.dzielenie:
            Console.WriteLine($"Wynik dzielenia: {Dzielenie()}");
            break;

          case OperacjeMatematyczne.pokazWyniki:
            pokazwyniki();
            break;

          case OperacjeMatematyczne.wyczyscListeWynikow:
            wyczyscListeWynikow();
            break;

          }
        }
        catch (OverflowException overflow)
        {
          Console.WriteLine($"{overflow}");
        }
      }
      
      
    }
    }
}
