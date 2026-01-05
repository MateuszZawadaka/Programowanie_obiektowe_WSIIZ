using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Book
    {
    public string Title { get; set; }
    public Person Author { get; set; }
    public string DataWydania { get; set; }


    public Book(string title, Person author, string dataWydania)
    {
      Title = title;
      Author = author;
      DataWydania = dataWydania;
    }

    public void View()
    {
      Console.WriteLine($"Tytuł: {Title}");
      Console.WriteLine($"Autor: {Author}");
      Console.WriteLine($"Data wydania: {DataWydania}");
    }
  }
}
