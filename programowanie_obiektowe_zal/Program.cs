

using programowanie_obiektowe_zal;

Zamowienie z1 = new Zamowienie( "Jan Kowalski");
Zamowienie z2 = new Zamowienie( "Anna Nowak");
Zamowienie z3 = new Zamowienie("Piotr Wiśniewski");
Zamowienie z4 = new Zamowienie("Katarzyna Wójcik");
Zamowienie z5 = new Zamowienie("Michał Kamiński");
Magazyn magazyn = new Magazyn();

Zamowienie[] zam = { z1, z2, z3, z4, z5 };


z1.DodajProdukt("Laptop");
z1.DodajProdukt("Myszka");
magazyn.DodajZamowienie(z1);

z2.DodajProdukt("Smartfon");
magazyn.DodajZamowienie(z2);

z3.DodajProdukt("Tablet");
z3.DodajProdukt("Etui");
magazyn.DodajZamowienie(z3);

z4.DodajProdukt("Monitor");
magazyn.DodajZamowienie(z4);

z5.DodajProdukt("Klawiatura");
magazyn.DodajZamowienie(z5);

magazyn.WyswietlWszystkieZamowienia();

foreach (var z in zam)
{
  z.ZmianaStatusu("W realizacji");
}

magazyn.WyswietlWszystkieZamowienia();


foreach(var z in zam)
{
  z.ZmianaStatusu("Zrealizowane");
}

foreach (var z in zam)
{
  if(z.StatusZamowienia == "Zrealizowane")
  {
    magazyn.UsunZamowienie(z.NumerZamowienia);
  }
}

magazyn.WyswietlWszystkieZamowienia();