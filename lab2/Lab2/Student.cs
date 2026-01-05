using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Student
    {
    private string Imie;
    private string Nazwisko;
    private int[] Oceny;
      public float SredniaOcen { get; private set; }


    public Student(string imie, string nazwisko)
    {
      Imie = imie;
      Nazwisko = nazwisko;
      Oceny = new int[0];
    }

    public void DodajOcene(int ocena)
    {
      List<int> listaOcen = Oceny.ToList();
      listaOcen.Add(ocena);
      Oceny = listaOcen.ToArray();

      SredniaOcen = srednia();

    }

    private float srednia()
    {
      int val = 0;
      foreach(int ocena in Oceny)
      {
        val += ocena;
      }
      return val / Oceny.Length;
    }
  }
}
