using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class PlayerStatistic
    {
        private string name;
        private int score;

        public PlayerStatistic()
        {
        }

        public PlayerStatistic(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
    }
}
