using System;
using GameModel;

namespace ConsoleGameUsingModel
{
    class Program
    {
        private static View view;
        private static Game model;

        static void Main(string[] args)
        {
            view = new View();
            view.ShowWelcome();
            StartPlayDecide();
        }

        static void StartGame()
        {
            int max = AskForMax();

            model = new Game(0, max);
            view.ShowStartText(0, max);
            MainLoop();

            if (model.State == Game.GameState.Won)
                view.ShowSuccess($"Wygrałeś za {model.MovesCounter} ruchem. Gratulacje!");
            else if (model.State == Game.GameState.GaveUp)
                view.ShowSuccess($"Poddałeś grę. Mało fajnie.");

            view.AskForRePlay();
            StartPlayDecide("t");
        }

        static void StartPlayDecide(string key = "")
        {
            string pressedKey = Console.ReadKey().KeyChar.ToString();

            if (key.Length == 1)
                if (key != pressedKey)
                    System.Environment.Exit(1);
            
            StartGame();
        }

        static int AskForMax()
        {
            int result = 0;
            string temp;

            while (result == 0)
            {
                try
                {
                    view.AskForRange();
                    temp = Console.ReadLine();
                    result = int.Parse(temp);
                }
                catch (FormatException)
                {
                    view.ShowError("Niepoprawny zapis liczby!");
                    result = 0;
                }
                catch (OverflowException)
                {
                    view.ShowError("Liczba za duża!");
                    result = 0;
                }

                if (result <= 0)
                {
                    view.ShowError("Góra granica musi być większa od zera.");
                    result = 0;
                }
            }

            return result;
        }

        static void MainLoop()
        {
            string temp;
            int answer;

            while (model.State == Game.GameState.During)
            {
                try
                {
                    view.AskForAnswer();
                    temp = Console.ReadLine();
                    answer = int.Parse(temp);
                }
                catch (FormatException)
                {
                    view.ShowError("Niepoprawny zapis liczby!");
                    continue;
                }
                catch
                {
                    view.ShowError("Liczba za duża!");
                    continue;
                }

                switch (model.CheckAnswer(answer))
                {
                    case Game.AnswerRate.TooMuch:
                        view.ShowError("Za dużo! Spróbuj mniejszą liczbę.");
                        break;
                    case Game.AnswerRate.NotEnough:
                        view.ShowError("Za mało! Dołóż do pieca!");
                        break;
                    case Game.AnswerRate.Correct:
                        view.ShowSuccess("To jest moja liczba!");
                        break;
                }
            }
        }
    }
}
