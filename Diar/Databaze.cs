using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diar
{
    internal class Databaze
    {
        private List<Zaznam> zaznamy;

        public Databaze()
        {
            zaznamy = new List<Zaznam>();   
        }

        // Přidání záznamu
        public void PridejZaznam(DateTime datumCas, string text)
        {
            zaznamy.Add(new Zaznam(datumCas, text));
        }

        // Hledání záznamů
        public List<Zaznam> NajdiZaznamy(DateTime datum, bool dleCasu)
        {
            List<Zaznam> nalezene = new List<Zaznam>();
            foreach (Zaznam z in zaznamy)
            {
                if (((dleCasu) && (z.DatumCas == datum)) // dle času a data
                ||
                ((!dleCasu) && (z.DatumCas.Date == datum.Date))) // pouze dle data
                    nalezene.Add(z);
            }
            return nalezene;
        }

        // Vymazání záznamů
        public void VymazZaznamy(DateTime datum)
        {
            List<Zaznam> nalezeno = NajdiZaznamy(datum, true);
                foreach (Zaznam z in nalezeno)
                        zaznamy.Remove(z);
        }
    }
}
