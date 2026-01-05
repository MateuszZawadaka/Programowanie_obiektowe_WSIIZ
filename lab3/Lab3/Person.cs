using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
  class Person
  {
    public string FirstName{get;set;}
    public string LastName { get; set; }

    public Person(string firstName, string lastName)
    {
      FirstName = firstName;
      LastName = lastName;
    }


    public void View()
    {
      Console.WriteLine($"Imię: {FirstName}");
      Console.WriteLine($"Nazwisko: {LastName}");

    }

    public override string ToString()
    {
      return $"{FirstName}, {LastName} ";
    }
  }
}
