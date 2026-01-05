using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Person
    {
    private string Name { get; set; }
    private string Surname { get; set; }

    private int Age { get; set;}


    public Person(string name, string surname, int age)
    {
      if(name.Length < 2)
      {
        throw new ArgumentException("Imię musi mieć conajmniej 2 znaki");
      }
      if (surname.Length < 2)
      {
        throw new ArgumentException("Nazwisko musi mieć conajmniej 2 znaki");
      }

      if(age < 0)
      {
        throw new ArgumentException("Wiek nie może być mniejszy od 0");
      }

      Name = name;
      Surname = surname;
      Age = age;
    }

    public void viewInfo()
    {
      Console.WriteLine($"Imię: {Name}");
      Console.WriteLine($"Nazwisko: {Surname}");
      Console.WriteLine($"Wiek: {Age}");
    }
  }
}
