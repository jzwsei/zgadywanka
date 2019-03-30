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

            bool win = false;

            do
            {
                #region propozycja
                Console.Write("Podaj swoją propozycję: ");

                int answer = 0;

                try
                {
                    answer = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Nie podano liczby");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Liczba nie mieści się w rejestrze");
                }


                Console.WriteLine($"Podałeś wartość: {answer}");
                #endregion propozycja 

                #region ocena
                if (answer < generatedNumber)
                    Console.WriteLine("Za mało!");
                else if (answer > generatedNumber)
                    Console.WriteLine("Za dużo!");
                else
                {
                    Console.WriteLine("Trafiono!");
                    win = true;
                }
                    
                #endregion ocena
            }
            while (!win);

            Console.WriteLine("Koniec gry");
        }
    }
}
