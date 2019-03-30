using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraMonolitycznie
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Witaj!");
            Console.Write("Podaj swoje imię: ");
            string x = Console.ReadLine();
            Console.WriteLine($"Witaj, {x}");*/

            Random generator = new Random();
            int generatedNumber = generator.Next(1, 101);

            Console.WriteLine("Wylosowałem liczbę w zakresie 1-100.\nZgadnij ją!");

#if (DEBUG)
            Console.WriteLine("Wylosowana liczba: " + generatedNumber);
#endif

            Console.Write("Podaj swoją propozycję: ");

            int answer = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Podałeś wartość: {answer}");

            if (answer < generatedNumber)
                Console.WriteLine("Za mało!");
            else if (answer > generatedNumber)
                Console.WriteLine("Za dużo!");
            else
                Console.WriteLine("Trafiono!");

            Console.WriteLine("Koniec gry");
        }
    }
}
