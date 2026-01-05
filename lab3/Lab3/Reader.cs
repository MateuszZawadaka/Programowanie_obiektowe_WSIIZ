using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Reader : Person
    {
      public List<Book> books = new List<Book> { };


      public Reader(string firstName, string lastname) : base(firstName, lastname)
      {
        FirstName = firstName;
        LastName = lastname;
      }

      public void ViewBook()
      {
        foreach(Book book in books)
        {
          Console.WriteLine($"Tytuł przeczytanej ksiazki: {book.Title}");
        }
      }

    public void AddBook(Book book)
    {
      books.Add(book);
    }

    public void View()
    {
      Console.WriteLine($"Imię: {FirstName}, nazwisko: {LastName}");
      ViewBook();
    }

    }
}
