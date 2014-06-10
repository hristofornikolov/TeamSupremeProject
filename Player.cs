namespace GameFifteenProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Player : IComparable
    {
        private string name;
        private int moves;

        public Player(string name, int moves)
        {
            this.Name = name;
            this.Moves = moves;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Moves
        {
            get { return this.moves; }
            set { this.moves = value; }
        }

        public int CompareTo(Player player)
        {
            Player currentPlayer = player;
            int result = this.Moves.CompareTo(currentPlayer.Moves);
            return result;
        }
    }
}
