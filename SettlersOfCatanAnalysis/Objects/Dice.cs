using System;
using System.Collections.Generic;

namespace SettlersOfCatanAnalysis.Objects
{
    /// <summary>
    /// Class to handle dice rolls and return probabilities
    /// </summary>
    public class Dice
    {
        /// <summary>
        /// Random object to be used to generate dice rolls
        /// </summary>
        public static Random Random = new Random();

        /// <summary>
        /// Returns the probability for rolling a certain combination
        /// </summary>
        public static List<double> Probability =
            new List<double>
            {
                0,
                0,
                1 / 36D,
                2 / 36D,
                3 / 36D,
                4 / 36D,
                5 / 36D,
                6 / 36D,
                5 / 36D,
                4 / 36D,
                3 / 36D,
                2 / 36D,
                1 / 36D
            };

        /// <summary>
        /// Rolls 2 dice and returns the sum
        /// </summary>
        /// <returns>Sum's the result of 2 dice roll</returns>
        public int RollDice()
        {
            var die1 = Random.Next(1, 7);
            var die2 = Random.Next(1, 7);
            return die1 + die2;
        }
    }
}
