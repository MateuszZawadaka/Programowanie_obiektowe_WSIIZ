// See https://aka.ms/new-console-template for more information
using Lab2;

Console.WriteLine("Hello, World!");


Person osoba1 = new Person("Maciek", "Kowalski", 12);

BankAccount osoba2 = new BankAccount("Jan", "Kowalski", 32, 10000);


Student nowyStudent = new Student("Krzysztof", "kapusta");

nowyStudent.DodajOcene(4);
nowyStudent.DodajOcene(2);
Console.WriteLine($"Srednia ocen studenta: {nowyStudent.SredniaOcen}");

osoba2.Wplata(200);

osoba1.viewInfo();