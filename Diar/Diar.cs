using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Diar
{
    internal class Diar
    {
        private Databaze databaze;

        public Diar()
        {
            databaze = new Databaze();
        }

        // Metoda vyzve uživatele k zadání časi
        private DateTime ZjistiDatumCas()
        {
            Console.WriteLine("Zadejte datum a čas ve tvaru [1.1.2012 14:00]:");
            DateTime datumCas;
            while (! DateTime.TryParse(Console.ReadLine(), out datumCas))
                Console.WriteLine("Chybné zadání, zadejte znovu datum a čas: ");
            return datumCas;
        }

        // Metoda vypíše záznamy
        public void VypisZaznamy(DateTime den)
        {
            List<Zaznam> zaznamy = databaze.NajdiZaznamy(den, false);
            foreach (Zaznam z in zaznamy)
                Console.WriteLine(z);
        }

        // Metoda pro přidání nového záznamu
        public void PridejZaznam()
        {
            DateTime datumcas = ZjistiDatumCas();
            Console.WriteLine("Zadejte text záznamu:");
            string text;
            while (string.IsNullOrWhiteSpace(text = Console.ReadLine()))
            {
                Console.WriteLine("Zadej text znovu:");
            }
            databaze.PridejZaznam(datumcas, text);
        }

        // Metoda vyhledá záznamy
        public void VyhledejZaznamy()
        {
            // zadání data uživatelem
            DateTime datumCas = ZjistiDatumCas();
            // vyhledání
            List<Zaznam> zaznamy = databaze.NajdiZaznamy(datumCas, false);
            // vípis záznamů
            if (zaznamy.Count() > 0)
            {
                Console.WriteLine("Nalezeny tyto záznamy: ");
                foreach (Zaznam z in zaznamy)
                    Console.WriteLine(z);
            }
            else
                // Nic nenalezeno
                Console.WriteLine("Nebyly nalezeny žádné záznamy.");
        }

        // Vymazání záznamů
        public void VymazZaznam()
        {
            Console.WriteLine("Budou vymazány záznamy v daný den a hodinu");
            DateTime datumcas = ZjistiDatumCas();
            databaze.VymazZaznamy(datumcas);
        }

        // úvodní obrazovka
        public void VypisUvodniObrazovku()
        {
            Console.Clear();
            Console.WriteLine("Vítejte v diáři!");
            Console.WriteLine("Dnes je: {0}", DateTime.Now);
            Console.WriteLine();
            // výpis hlavní obrazovky
            Console.WriteLine("Dnes:\n------");
            VypisZaznamy(DateTime.Today);  // vypíše úkoly pro dnešní datum
            Console.WriteLine();
            Console.WriteLine("Zítra:\n------"); // vypíše úkoly na následující den
            VypisZaznamy(DateTime.Now.AddDays(1));
            Console.WriteLine();

        }
            
        
    }
}
