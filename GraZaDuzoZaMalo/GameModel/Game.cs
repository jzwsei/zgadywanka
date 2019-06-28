using System;

namespace GameModel
{
    public partial class Game
    {
        public enum AnswerRate { TooMuch = 1, NotEnough = -1, Correct = 0 };
        public enum GameState { During, GaveUp, Won };

        public readonly int rangeFrom, rangeTo;
        public int MovesCounter { get; private set; } = 0;
        public GameState State { get; private set; } = GameState.During;
        private int answer;

        public Game(int rangeFrom, int rangeTo)
        {
            this.rangeFrom = rangeFrom;
            this.rangeTo = rangeTo;
            this.DetermineAnswer();
            this.History = new System.Collections.Generic.List<Move>();
        }

        public AnswerRate CheckAnswer(int answerToCheck)
        {
            AnswerRate rate;

            if (answerToCheck < this.answer)
                rate = AnswerRate.NotEnough;
            else if (answerToCheck > this.answer)
                rate = AnswerRate.TooMuch;
            else
            {
                rate = AnswerRate.Correct;
                this.State = GameState.Won;
            }

            this.MovesCounter++;
            this.AddToHistory(answerToCheck, rate);

            return rate;
        }

        public void GiveUp()
        {
            this.State = GameState.GaveUp;
        }

        public int? GetAnswer()
        {
            if (this.State != GameState.During)
                return this.answer;

            return null;
        }

        private void DetermineAnswer()
        {
            this.answer = this.GetRandomNumber(this.rangeFrom, this.rangeTo);
        }

        private int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }
    }
}
