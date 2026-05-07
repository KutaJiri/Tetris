using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    public class Hrac
    {
        public string Prezdivka { get; set; }
        public int PocetBodu { get; set; }


        public Hrac(string Prezdivka, int PocetBodu)
        {
            this.Prezdivka = Prezdivka;
            this.PocetBodu = PocetBodu;
        }

      
    }
}
