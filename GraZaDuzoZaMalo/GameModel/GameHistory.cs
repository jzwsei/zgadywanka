using System;
using System.Collections.Generic;
using System.Text;

namespace GameModel
{
    public partial class Game
    {
        public List<Move> History;

        public class Move
        {
            public readonly int Answer;
            public readonly AnswerRate Rate;
            public readonly DateTime Time;

            public Move(int answer, AnswerRate rate)
            {
                this.Answer = answer;
                this.Rate = rate;
                this.Time = DateTime.Now;
            }

            public override string ToString() => $"[{this.Time}] {this.Answer} - {this.Rate}";
        }

        private void AddToHistory(int answer, AnswerRate rate)
        {
            this.History.Add(new Move(answer, rate));
        }
    }
}
