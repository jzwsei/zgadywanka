using System;

namespace GameModel
{
    public class Game
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
        }

        public AnswerRate CheckAnswer(int answerToCheck)
        {
            this.MovesCounter++;

            if (answerToCheck < this.answer)
                return AnswerRate.NotEnough;

            if (answerToCheck > this.answer)
                return AnswerRate.TooMuch;

            this.State = GameState.Won;

            return AnswerRate.Correct;
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
