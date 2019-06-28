using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameUsingModel
{
    class View
    {
        public void ShowWelcome()
        {
            Console.Clear();
            Console.WriteLine(@"
╔═══════════════════╗
║ ZA DUŻO - ZA MAŁO ║
╠═══════════════════╣
║ (c) Jarosław Żak  ║
╚═══════════════════╝

Witaj w grze 'Za dużo - za mało'. 

Twoim zadaniem będzie odgadnąć liczbę wymyśloną przeze mnie. 
Będę udzielał Ci cennych wskazówek!

Gdy będziesz gotowy, naciśnij dowolny klawisz.");
        }

        public void AskForRange()
        {
            Console.WriteLine("Jak wielką liczbę wylosować? Podaj jej górną granicę (dolna to 0): ");
        }

        public void AskForAnswer()
        {
            Console.WriteLine("Podaj propozycję odpowiedzi: ");
        }

        public void AskForRePlay()
        {
            Console.WriteLine(@"
Czy chcesz zagrać ponownie? (t/n)");
        }

        public void ShowStartText(int min, int max)
        {
            Console.Clear();
            ShowColorText($@"Wylosowałem dla Ciebie liczbę mniejszą od {max} i większą od {min}.
", ConsoleColor.Yellow);
        }
        public void ShowError(string text)
        {
            ShowColorText(text, ConsoleColor.Red);
        }
        public void ShowSuccess(string text)
        {
            ShowColorText(text, ConsoleColor.Green);
        }

        public void ShowColorText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
