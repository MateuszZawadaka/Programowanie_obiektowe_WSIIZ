
using Lab4;

Employee pracownik1 = new Employee("Jan", "Kowalski");

Position pozycja = new Position(50000m, 50);

pracownik1.ZmienKontrakt(pozycja);
Console.WriteLine(pracownik1.Salary());
