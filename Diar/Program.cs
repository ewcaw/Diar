namespace Diar
{
    class Program
    {
        static void Main(string[] args)
        {
            // instalace diáře
            Diar diar = new Diar();
            char volba = '0';
            // hlavní cyklus
            while (volba != '4')
            {
                diar.VypisUvodniObrazovku();
                Console.WriteLine();
                Console.WriteLine("Vyberte si akci:");
                Console.WriteLine("1 - Přidat záznam");
                Console.WriteLine("2 - Vyhledat záznamy");
                Console.WriteLine("3 - Vymazat záznam");
                Console.WriteLine("4 - Konec");
                volba = Console.ReadKey().KeyChar;
                Console.WriteLine();

                // reakce na volbu
                switch (volba)
                {
                    case '1':
                        diar.PridejZaznam();
                        break;
                    case '2':
                        diar.VyhledejZaznamy();
                        break;
                    case '3':
                        diar.VymazZaznam();
                        break;
                    case '4':
                        Console.WriteLine("Libovolnou klávesou ukončíte program ...");
                        break;
                    default:
                        Console.WriteLine("neplatná volba, stiskněte libovolnou klávesu a opakujte volbu.");
                        break;
                }

                Console.ReadKey();
                    
            }
        }
    }
}
