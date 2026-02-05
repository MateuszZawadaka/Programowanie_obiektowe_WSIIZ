using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programowanie_obiektowe_zal
{
  class Magazyn : IMagazyn
  {
    private List<Zamowienie> zamowienia = new List<Zamowienie>();

    public void DodajZamowienie(Zamowienie z)
    {
      zamowienia.Add(z);
    }

    public void UsunZamowienie(string numerZamowienia)
    {
      zamowienia.RemoveAll(z => z.NumerZamowienia == numerZamowienia);
    }

   public void WyswietlWszystkieZamowienia()
    {
      foreach (var zamowienie in zamowienia)
      {
        zamowienie.Wyswietl();
      }
    }
    public void ZnajdzZamowienie(string numerZamowienia)
    {
      var zamowienie = zamowienia.FirstOrDefault(z => z.NumerZamowienia == numerZamowienia);
      if (zamowienie != null)
      {
        zamowienie.Wyswietl();
      }
      else
      {
        Console.WriteLine("Zamówienie nie znalezione.");
      }
    }
  }
}
