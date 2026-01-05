using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Employee
    {
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public IContract Contract { get; private set; }

    public Employee(string firstName, string lastName)
    {
      FirstName = firstName;
      LastName = lastName;
      Contract = new Internship(1000m);
    }

    public Employee(string firstName, string lastName, IContract contract) : this(firstName, lastName)
    {
      Contract = contract;
    }

    public void ZmienKontrakt(IContract nowykontrakt)
    {
      Contract = nowykontrakt;
    }

    public decimal Salary()
    {
      return Contract.Salary();
    }

    public override string ToString()
    {
      return $"Imię: {FirstName}, Nazwisko: {LastName}, wynagrodzenie: {Salary()}";
    }
  }
}
