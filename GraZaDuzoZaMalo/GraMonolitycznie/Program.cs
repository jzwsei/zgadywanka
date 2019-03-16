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
            Console.WriteLine("Witaj!");
            Console.Write("Podaj swoje imię: ");
            string x = Console.ReadLine();
            Console.WriteLine($"Witaj, {x}");
        }
    }
}
