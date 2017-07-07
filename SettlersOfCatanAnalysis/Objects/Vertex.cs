using System;

namespace SettlersOfCatanAnalysis.Objects
{
    public class Vertex
    {
        /// <summary>
        /// Name of the structure build upon a vertex
        /// </summary>
        public enum Structure
        {
            None,
            Settlement,
            City
        }

        /// <summary>
        /// Integer representation of the current occupation of a vertex
        /// </summary>
        public Structure Plot { get; private set; }

        /// <summary>
        /// Integer representation of the current colour occupying a vertex
        /// </summary>
        public Player.Colour Colour { get; private set; }

        /// <summary>
        /// Initialises a vertex
        /// </summary>
        /// <param name="plot">The structure that is built upon the vertex</param>
        /// <param name="colour">The colour of the structure that is built upon the vertex</param>
        public Vertex(Structure plot, Player.Colour colour)
        {
            if (!Enum.IsDefined(typeof(Player.Colour), colour))
                throw new ArgumentOutOfRangeException(nameof(colour), "Value should be defined in the Colour enum.");
            if (!Enum.IsDefined(typeof(Structure), plot))
                throw new ArgumentOutOfRangeException(nameof(plot), "Value should be defined in the Structure enum.");
            Plot = plot;
            Colour = colour;
        }

        /// <summary>
        /// Initialse an empty vertex
        /// </summary>
        public Vertex()
        {
            Plot = Structure.None;
            Colour = Player.Colour.None;
        }

        /// <summary>
        /// Upgrades the vertex to the next Structure
        /// </summary>
        /// <param name="colour">The colour of the player upgrading</param>
        /// <returns>True if upgrade succsessful</returns>
        public bool UpgradeVertex(Player.Colour colour)
        {
            if (!Enum.IsDefined(typeof(Player.Colour), colour))
                throw new ArgumentOutOfRangeException(nameof(colour), "Value should be defined in the Colour enum.");
            // If we are at full structure and the player requesting is the correct colour
            if (Plot == Structure.City || (Colour != Player.Colour.None && colour != Colour))
                return false;
            Colour = colour;
            switch (Plot)
            {
                    case Structure.None:
                    Plot = Structure.Settlement;
                        break;

                    case Structure.Settlement:
                    Plot = Structure.City;
                        break;
            }
            return true;
        }
    }
}
