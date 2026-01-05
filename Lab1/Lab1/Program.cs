// See https://aka.ms/new-console-template for more information
using Lab1;

Console.WriteLine("Hello, World!");

Ex1 zad1 = new Ex1();
Ex2 zad2 = new Ex2();
Ex3 zad3 = new Ex3();
Ex4 zad4 = new Ex4();


zad1.run();
zad2.setNumbers();

Console.WriteLine($"SUma z tablicy: {zad2.sum()}");
Console.WriteLine($"Iloczyn elementów z tablicy: {zad2.multiplication()}");
Console.WriteLine($"Średnia wartość  z tablicy: {zad2.average()}");
Console.WriteLine($"minimalna wartość z tablicy: {zad2.minValue()}");
Console.WriteLine($"maxymalna wartość z tablicy: {zad2.maxValue()}");

zad3.show();
zad4.run();