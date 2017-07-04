using System;
using System.Collections;
using System.Collections.Generic;

namespace SettlersOfCatanAnalysis.Objects
{
    /// <summary>
    /// Defines a hex that is on the board
    /// </summary>
    public class Hex
    {
        /// <summary>
        /// Defines the type of terrains available to use
        /// </summary>
        public enum TerrainType
        {
            Hills,
            Pasture,
            Mountains,
            Fields,
            Forest,
            Desert
        }

        /// <summary>
        /// The terrain on the hex tile
        /// </summary>
        public TerrainType Terrain { get; }

        /// <summary>
        /// The number allocated to this hex tile
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// A list of the local vertices going clockwise
        /// </summary>
        public List<int> LocalVertex { get; }
        
        /// <summary>
        /// A list of the local Edges going clockwise
        /// </summary>
        public List<int> LocalEdge { get; }

        /// <summary>
        /// Is a robber on the hex
        /// </summary>
        public bool IsRobber { get; set; }

        /// <summary>
        /// Initialise a hex tile
        /// </summary>
        /// <param name="terrain">Terrain of the hex tile</param>
        /// <param name="number">The number allocated to the hex tile</param>
        public Hex(TerrainType terrain, int number)
        {
            //if (number < 0) throw new ArgumentOutOfRangeException(nameof(number));
            Terrain = terrain;
            Number = number;
            LocalVertex = new List<int>();
            LocalEdge = new List<int>();
        }
    }
}
