using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diar
{
    class Zaznam
    {
        // Vlastnosti
        public DateTime DatumCas { get; set; }
        public string Text { get; set; }

        // Konstruktor
        public Zaznam (DateTime datumCas, string text)
        {
            DatumCas = datumCas;
            Text = text;
        }

        // ToString
        public override string ToString()
        {
            return DatumCas + " " + Text;
        }
    }
}
