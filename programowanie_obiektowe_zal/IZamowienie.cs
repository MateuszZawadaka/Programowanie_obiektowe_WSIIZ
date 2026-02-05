using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programowanie_obiektowe_zal
{
    interface IZamowienie
    {

    void DodajProdukt(string nazwaProduktu);
    void ZmianaStatusu(string nowyStatus);
  }
}
