using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programowanie_obiektowe_zal
{
    class Zamowienie : IZamowienie
    {
    private static int licznikZamowien = 0;
    public string NumerZamowienia = licznikZamowien.ToString("D3");
    public string Klient { get; set; }
    public List<string> ListaProduktow { get; set; }
    public string StatusZamowienia { get; set; }

    public Zamowienie()
    {
      licznikZamowien++;
      this.ListaProduktow = new List<string>();
      this.StatusZamowienia = "Nowe";
      this.NumerZamowienia = licznikZamowien.ToString("D3");

    }

    public Zamowienie(string klient)
    {
      licznikZamowien++;
      this.NumerZamowienia = licznikZamowien.ToString("D3");
      this.Klient = klient;
      this.ListaProduktow = new List<string>();
      this.StatusZamowienia = "Nowe";
      
    }

    public void DodajProdukt(string produkt)
    {
      ListaProduktow.Add(produkt);
    }

    public void ZmianaStatusu(string nowyStatus)
    {
      StatusZamowienia = nowyStatus;
    }

    public void Wyswietl()
    {
      Console.WriteLine($"Numer zamówienia: {NumerZamowienia}");
      Console.WriteLine($"Klient: {Klient}");
      Console.WriteLine($"Status: {StatusZamowienia}");
      Console.WriteLine("Produkty:");


      foreach (var produkt in ListaProduktow)
      {
        Console.WriteLine($"- {produkt}");
      }

      Console.WriteLine();
    }

  }
}
