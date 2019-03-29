using System;
using System.Collections.Generic;
using System.Linq;

namespace SettlersOfCatanAnalysis.Objects
{
    public class AiProperties
    {
        /// <summary>
        /// List of preferences for terrain type indexed by Enum <see cref="SettlersOfCatanAnalysis.Objects.Hex.TerrainType"/>. must be between 1/36 and 1
        /// </summary>
        public List<double> HexTilePreference { get; }

        /// <summary>
        /// Priority given to hex tiles for starting settlements. Between 0 and 1
        /// </summary>
        public double HexPreference { get; }

        /// <summary>
        /// Priority given to number on hex tiles for starting settlements. Between 0 and 1
        /// </summary>
        public double DiceRollPreference { get; }

        /// <summary>
        /// Initiates a new Ai Properties class
        /// </summary>
        /// <param name="hexTilePreference">List of preferences for terrain type indexed by Enum <see cref="SettlersOfCatanAnalysis.Objects.Hex.TerrainType"/>. must be between 1/36 and 1</param>
        /// <param name="hexPreference">Priority given to hex tiles for starting settlements. Between 0 and 1</param>
        /// <param name="diceRollPreference">Priority given to number on hex tiles for starting settlements. Between 0 and 1</param>
        public AiProperties(List<double> hexTilePreference, double hexPreference, double diceRollPreference)
        {
            if (HexTilePreference.Any(h => !(h >= (1/36D)) || !(h < 1)))
            {
                throw new ArgumentOutOfRangeException();
            }
            HexTilePreference = hexTilePreference;
            DiceRollPreference = diceRollPreference;
            HexPreference = hexPreference;
        }
    }
}
