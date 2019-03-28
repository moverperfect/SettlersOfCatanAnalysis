using System;
using System.Collections.Generic;

namespace SettlersOfCatanAnalysis.Objects
{
    public class Player
    {
        /// <summary>
        /// Colours available for players to use
        /// </summary>
        public enum Colour
        {
            None,
            Blue,
            White,
            Red,
            Orange
        }

        /// <summary>
        /// Returns the colour of this player
        /// </summary>
        public Colour PlayerColour { get; }

        /// <summary>
        /// Returns the number of cities that are available to a player
        /// </summary>
        public int NoOfCities { get; } = 4;

        /// <summary>
        /// Returns the number of settlements available to a player
        /// </summary>
        public int NoOfSettlements { get; } = 5;

        /// <summary>
        /// Returns the number of roads available to a player
        /// </summary>
        public int NoOfRoads { get; } = 15;

        /// <summary>
        /// Indicates whether this is an AI player
        /// </summary>
        public bool IsAi { get; }

        /// <summary>
        /// Indicates the number of turns this player has played
        /// </summary>
        public int TurnCount { get; private set; }

        /// <summary>
        /// List of AI properties for the player
        /// </summary>
        public AiProperties AiProperties { get; }

        /// <summary>
        /// Initialise the player
        /// </summary>
        /// <param name="playerColour">The colour of the player</param>
        /// <param name="aiProperties">A list of properties for the AI</param>
        public Player(Colour playerColour, AiProperties aiProperties)
        {
            if (!Enum.IsDefined(typeof(Colour), playerColour))
                throw new ArgumentOutOfRangeException(nameof(playerColour),
                    "Value should be defined in the Colour enum.");
            IsAi = true;
            AiProperties = aiProperties ?? throw new ArgumentNullException(nameof(aiProperties));
            PlayerColour = playerColour;
            TurnCount = 0;
        }

        /// <summary>
        /// Initialises a normal human player
        /// </summary>
        /// <param name="playerColour">The colour for the new player</param>
        public Player(Colour playerColour)
        {
            IsAi = false;
            PlayerColour = playerColour;
            TurnCount = 0;
        }

        /// <summary>
        /// Build an initial starting settlement
        /// </summary>
        /// <param name="board">The board that the player is playing on</param>
        /// <returns>Successful implementation of settlement</returns>
        public bool BuildStartSettlement(Board board)
        {
            return TurnCount <= 2 && BuySettlement(true, board);
        }

        /// <summary>
        /// Attempt to buy a normal settlement
        /// </summary>
        /// <param name="board">The board to place the settlement on</param>
        /// <returns></returns>
        public bool BuySettlement(Board board)
        {
            return BuySettlement(false, board);
        }

        private bool BuySettlement(bool startSettlement, Board board)
        {
            // TODO Detect if we have enough resources to create a settlement
            //if()

            if (IsAi)
            {
                // TODO Code the Artifical inteligence for creating a starting settlement
                // Strategies:
                // Random Choice
                // Weighted for numbers that have a higher chance of being rolled
                // Weighted for specific resources
                var availableVertices = board.GetAvailableVertices(false);
                var sumVertexPoints = new List<double>();
                var sumHexPoints = new List<double>();
                var sumPointsPoints = new List<double>();

                foreach (var vertex in availableVertices)
                {
                    for (int i = 0; i < board.IslandVertices[vertex].LocalHexes.Count; i++)
                    {
                        if (board.IslandVertices[vertex].LocalHexes[i] == -1)
                            continue;
                        //sumHexPoints[vertex]
                    }
                }
            }
            else
            {
                Console.WriteLine("Where would you like to place your settlement?");
                var tempVertex = Console.ReadLine();
                int result = 0;
                while (!int.TryParse(tempVertex, out result) && result < 20 && result > 0)
                {
                    Console.WriteLine("Invalid entry, please try again");
                    tempVertex = Console.ReadLine();
                }

                // TODO Code creating a settlement with user participation
                if (startSettlement)
                {
                    //board.IslandVertices[result].Plot = Vertex.Structure.Settlement;
                }
            }
            return false;
        }
    }
}
