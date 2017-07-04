﻿using System;

namespace SettlersOfCatanAnalysis.Objects
{
    internal class Player
    {
        /// <summary>
        /// Colours available for players to use
        /// </summary>
        internal enum Colour
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
        internal Colour PlayerColour { get; }

        /// <summary>
        /// Returns the number of cities that are available to a player
        /// </summary>
        internal int NoOfCities { get; } = 4;

        /// <summary>
        /// Returns the number of settlements available to a player
        /// </summary>
        internal int NoOfSettlements { get; } = 5;

        /// <summary>
        /// Returns the number of roads available to a player
        /// </summary>
        internal int NoOfRoads { get; } = 15;

        /// <summary>
        /// Indicates whether this is an AI player
        /// </summary>
        internal bool IsAi { get; }

        /// <summary>
        /// Initialise the player
        /// </summary>
        /// <param name="isAi">Is this player an AI</param>
        /// <param name="playerColour">The colour of the player</param>
        internal Player(bool isAi, Colour playerColour)
        {
            IsAi = isAi;
            PlayerColour = playerColour;
        }

        /// <summary>
        /// Choose a starting settlement
        /// </summary>
        /// <param name="board">The board that the player is playing on</param>
        internal void StartSettlement(Board board)
        {
            BuySettlement(true, board);
        }

        internal void BuySettlement(Board board)
        {
            BuySettlement(false, board);
        }

        private void BuySettlement(bool startSettlement, Board board)
        {
            // TODO Detect if we have enough resources to create a settlement
            //if()

            if (IsAi)
            {

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

                if (startSettlement)
                {
                    board.IslandVertices[result].Plot = Vertex.Structure.Settlement;
                }
            }
        }
    }
}