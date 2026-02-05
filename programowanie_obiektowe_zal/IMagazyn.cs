using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programowanie_obiektowe_zal
{
    interface IMagazyn
    {
    public void DodajZamowienie(Zamowienie z);
    public void UsunZamowienie(string numerZamowienia);
    public void WyswietlWszystkieZamowienia();

    }
}
