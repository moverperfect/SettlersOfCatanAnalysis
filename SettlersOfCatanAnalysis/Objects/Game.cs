using System.Collections.Generic;

namespace SettlersOfCatanAnalysis.Objects
{
    internal class Game
    {
        /// <summary>
        /// Indicates whether we are playing with a randomly generated board or not
        /// </summary>
        private readonly bool _randomBoard;

        /// <summary>
        /// The board that this game is playing on
        /// </summary>
        internal Board Board { get; private set; }

        /// <summary>
        /// A list of the current players in the game
        /// </summary>
        internal List<Player> Players { get; }

        /// <summary>
        /// Initiate a game
        /// </summary>
        /// <param name="randomBoard">Is the board in this game random</param>
        internal Game(bool randomBoard)
        {
            Players = new List<Player> {new Player(Player.Colour.Blue), new Player(Player.Colour.Orange)};
            _randomBoard = randomBoard;
            InitiateBoard(_randomBoard);
        }


        private bool InitiateBoard(bool randomBoard)
        {
            Board = new Board(randomBoard);

            return true;
        }

        internal bool Start()
        {
            var gameComplete = false;

            // Place initial settlements
            for (var i = 0; i < Players.Count; i++)
            {
                Players[i].BuildStartSettlement(Board);
            }

            // While we are still going
            while (!gameComplete)
            {
                for (var i = 0; i < Players.Count; i++)
                {
                    
                }
            }
            return true;
        }
    }
}
