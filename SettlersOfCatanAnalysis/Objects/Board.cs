using System;
using System.Collections.Generic;

namespace SettlersOfCatanAnalysis.Objects
{
    /// <summary>
    ///     Defines the board for the game, the index for each tile is layed out below
    ///     .           _______________________________
    ///     .          /       0       1       2       \
    ///     .         /0     _/ \_   _/ \_   _/ \_      \
    ///     .        /     3/     \4/     \5/     \6     \
    ///     .       /6     |   0   |   1   |   2   |      \
    ///     .      /       7       8       9      10       \
    ///     .     /10    _/ \_ 1 _/ \_ 1 _/ \_ 1 _/ \_      \
    ///     .    /    11/     \2/     \3/     \4/     \15    \
    ///     .   /18    |   3   |   4   |   5   |   6   |      \
    ///     .  /       1       1       1       1       2       \
    ///     . /23    _/6\_ 2 _/7\_ 2 _/8\_ 2 _/9\_ 2 _/0\_      \
    ///     ./    21/     \2/     \3/     \4/     \5/     \26    \
    ///     /      |   7   |   8   |   9   |  10   |  11   |      \
    ///     \      |       2       2       3       3       |      /
    ///     .\    27\_   _/8\_   _/9\_   _/0\_   _/1\_   _/32    /
    ///     . \       \3/     \3/     \3/     \3/     \3/       /
    ///     .  \       3  12   4  13   5  14   6  15   7       /
    ///     .   \      |       3       4       4       |      /
    ///     .    \    38\_   _/9\_   _/0\_   _/1\_   _/42    /
    ///     .     \       \_/     \4/     \4/     \4/       /
    ///     .      \     43|  16   4  17   5  18   6       /
    ///     .       \      |       |       |       |      /
    ///     .        \    47\_   _/4\_   _/4\_   _/50    /
    ///     .         \       \5/  8  \5/  9  \5/       /
    ///     .          \_______1_______2_______3_______/
    /// </summary>
    public class Board
    {
        public Board(bool random)
        {
            // Initialise the board with empty hexes
            Island = new List<Hex>();
            for (var i = 0; i < 19; i++)
                Island.Add(new Hex(Hex.TerrainType.Desert, 0));

            if (random)
            {
                // Populate the board with random hexes
                var hexes = new List<int> {1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6};
                var randomGen = new Random();
                // For each hex in the island, allocate it a terrain type randomly
                for (var i = 0; i < Island.Count; i++)
                {
                    var ranInt = randomGen.Next(0, hexes.Count);
                    switch (hexes[ranInt])
                    {
                        case 1:
                            Island[i] = new Hex(Hex.TerrainType.Forest, -1);
                            hexes.RemoveAt(ranInt);
                            continue;
                        case 2:
                            Island[i] = new Hex(Hex.TerrainType.Pasture, -1);
                            hexes.RemoveAt(ranInt);
                            continue;
                        case 3:
                            Island[i] = new Hex(Hex.TerrainType.Fields, -1);
                            hexes.RemoveAt(ranInt);
                            continue;
                        case 4:
                            Island[i] = new Hex(Hex.TerrainType.Hills, -1);
                            hexes.RemoveAt(ranInt);
                            continue;
                        case 5:
                            Island[i] = new Hex(Hex.TerrainType.Mountains, -1);
                            hexes.RemoveAt(ranInt);
                            continue;
                        case 6:
                            Island[i] = new Hex(Hex.TerrainType.Desert, -1);
                            hexes.RemoveAt(ranInt);
                            continue;
                    }
                }

                // Assign the numbers to the board( This should produce the same results everytime as there are no random numbers involved)
                var iterateOrder = new List<int> {0, 3, 7, 12, 16, 17, 18, 15, 11, 6, 2, 1, 4, 8, 13, 14, 10, 5, 9};
                var alphabeticalOrder = new List<int> {5, 2, 6, 3, 8, 10, 9, 12, 11, 4, 8, 10, 9, 4, 5, 6, 3, 11};
                
                var count = 0;
                foreach (var t in iterateOrder)
                {
                    if (Island[t].Terrain == Hex.TerrainType.Desert)
                        continue;
                    Island[t] = new Hex(Island[t].Terrain, alphabeticalOrder[count]);
                    count++;
                }
            }
            else
            {
                // 4 Forest
                // 4 Pasture
                // 4 Fields
                // 3 Hills
                // 3 Mountains
                // 1 Desert
                // 19 Hexes
                Island[0] = new Hex(Hex.TerrainType.Forest, 11);
                Island[1] = new Hex(Hex.TerrainType.Pasture, 12);
                Island[2] = new Hex(Hex.TerrainType.Fields, 9);
                Island[3] = new Hex(Hex.TerrainType.Hills, 4);
                Island[4] = new Hex(Hex.TerrainType.Mountains, 6);
                Island[5] = new Hex(Hex.TerrainType.Hills, 5);
                Island[6] = new Hex(Hex.TerrainType.Pasture, 10);
                Island[7] = new Hex(Hex.TerrainType.Desert, -1);
                Island[8] = new Hex(Hex.TerrainType.Forest, 3);
                Island[9] = new Hex(Hex.TerrainType.Fields, 11);
                Island[10] = new Hex(Hex.TerrainType.Forest, 4);
                Island[11] = new Hex(Hex.TerrainType.Fields, 8);
                Island[12] = new Hex(Hex.TerrainType.Hills, 8);
                Island[13] = new Hex(Hex.TerrainType.Pasture, 10);
                Island[14] = new Hex(Hex.TerrainType.Pasture, 9);
                Island[15] = new Hex(Hex.TerrainType.Mountains, 3);
                Island[16] = new Hex(Hex.TerrainType.Mountains, 5);
                Island[17] = new Hex(Hex.TerrainType.Fields, 2);
                Island[18] = new Hex(Hex.TerrainType.Forest, 6);
            }

            // Place the robber on the Desert
            foreach (var t in Island)
            {
                if (t.Terrain != Hex.TerrainType.Desert) continue;
                t.IsRobber = true;
                break;
            }
            
            // Hard code the local vertex positions
            Island[0].LocalVertex.AddRange(new[] {0, 4, 8, 12, 7, 3});
            Island[1].LocalVertex.AddRange(new[] {1, 5, 9, 13, 8, 4});
            Island[2].LocalVertex.AddRange(new[] {2, 6, 10, 14, 9, 5});
            Island[3].LocalVertex.AddRange(new[] {7, 12, 17, 22, 16, 11});
            Island[4].LocalVertex.AddRange(new[] {8, 13, 18, 23, 17, 12});
            Island[5].LocalVertex.AddRange(new[] {9, 14, 19, 24, 18, 13});
            Island[6].LocalVertex.AddRange(new[] {10, 15, 20, 25, 19, 14});
            Island[7].LocalVertex.AddRange(new[] {16, 22, 28, 33, 27, 21});
            Island[8].LocalVertex.AddRange(new[] {17, 23, 29, 34, 28, 22});
            Island[9].LocalVertex.AddRange(new[] {18, 24, 30, 35, 29, 23});
            Island[10].LocalVertex.AddRange(new[] {19, 25, 31, 36, 30, 24});
            Island[11].LocalVertex.AddRange(new[] {20, 26, 32, 37, 31, 25});
            Island[12].LocalVertex.AddRange(new[] {28, 34, 39, 43, 38, 33});
            Island[13].LocalVertex.AddRange(new[] {29, 35, 40, 44, 39, 34});
            Island[14].LocalVertex.AddRange(new[] {30, 36, 41, 45, 40, 35});
            Island[15].LocalVertex.AddRange(new[] {31, 37, 42, 46, 41, 36});
            Island[16].LocalVertex.AddRange(new[] {39, 44, 48, 51, 47, 43});
            Island[17].LocalVertex.AddRange(new[] {40, 45, 49, 52, 48, 44});
            Island[18].LocalVertex.AddRange(new[] {41, 46, 50, 53, 49, 45});

            // Hard code the local edge positions
            Island[0].LocalEdge.AddRange(new[] {1, 7, 12, 11, 6, 0});
            Island[1].LocalEdge.AddRange(new[] {3, 8, 14, 13, 7, 2});
            Island[2].LocalEdge.AddRange(new[] {5, 9, 16, 15, 8, 4});
            Island[3].LocalEdge.AddRange(new[] {11, 19, 25, 24, 18, 10});
            Island[4].LocalEdge.AddRange(new[] {13, 20, 27, 26, 19, 12});
            Island[5].LocalEdge.AddRange(new[] {15, 21, 29, 28, 20, 14});
            Island[6].LocalEdge.AddRange(new[] {17, 22, 31, 30, 21, 16});
            Island[7].LocalEdge.AddRange(new[] {24, 34, 40, 39, 33, 23});
            Island[8].LocalEdge.AddRange(new[] {26, 35, 42, 41, 34, 25});
            Island[9].LocalEdge.AddRange(new[] {28, 36, 44, 43, 35, 27});
            Island[10].LocalEdge.AddRange(new[] {30, 37, 46, 45, 36, 29});
            Island[11].LocalEdge.AddRange(new[] {32, 38, 48, 47, 37, 31});
            Island[12].LocalEdge.AddRange(new[] {41, 50, 55, 54, 49, 40});
            Island[13].LocalEdge.AddRange(new[] {43, 51, 57, 56, 50, 42});
            Island[14].LocalEdge.AddRange(new[] {45, 52, 59, 58, 51, 44});
            Island[15].LocalEdge.AddRange(new[] {47, 53, 61, 60, 52, 46});
            Island[16].LocalEdge.AddRange(new[] { 56, 63, 67, 66, 62, 55 });
            Island[17].LocalEdge.AddRange(new[] { 58, 64, 69, 68, 63, 57 });
            Island[18].LocalEdge.AddRange(new[] { 60, 65, 71, 70, 64, 59 });

            // Initialise collection of empty vertices
            IslandVertices = new List<Vertex>();
            for (var i = 0; i <= 53; i++)
            {
                IslandVertices.Add(new Vertex());
            }

            // Initialise collection of empty edges
            IslandEdges = new List<Edge>();
            for (var i = 0; i < 72; i++)
            {
                IslandEdges.Add(new Edge());
            }
        }

        /// <summary>
        /// Collection of Hexes that represent an island
        /// </summary>
        public List<Hex> Island { get; }

        /// <summary>
        /// Collection of Vertices at the intersections of hexes
        /// </summary>
        public List<Vertex> IslandVertices { get; }

        /// <summary>
        /// Collection of Edges that make up the island
        /// </summary>
        public List<Edge> IslandEdges { get; }
    }
}