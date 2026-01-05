
using Lab3;


Person AdamMickiewicz = new Person("Adam", "Mickiewicz");
Person AndrzejDragan = new Person("Andrzej", "Dragan");

Book[] ksiazki;

ksiazki = new Book[4];

ksiazki[0] = new Book("Pan Tadeusz", AdamMickiewicz, "12.01.2137");
ksiazki[1] = new Book("Kwantechizm 2.0", AndrzejDragan, "21.12.2022");
ksiazki[2] = new Book("Dziady cz.V", AdamMickiewicz, "21.37.2137");
ksiazki[3] = new Book("Dziady cz.II", AdamMickiewicz, "22.11.2137");


Reader[] readers;
readers = new Reader[4];

readers[0] = new Reader("Jakub", "Gondolik");
readers[1] = new Reader("Jan", "Kowalczyk");
readers[2] = new Reader("Mateusz", "Długi");
readers[3] = new Reader("Tadeusz", "Norek");

for(int i = 0; i <readers.Length; i++)
{
  for (int j = 0; j < ksiazki.Length; j++) 
  { 
    readers[i].AddBook(ksiazki[j]);
  }
  
}

foreach(Reader reader in readers)
{
  reader.View();
}
