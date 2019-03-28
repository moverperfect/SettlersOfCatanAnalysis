using Microsoft.VisualStudio.TestTools.UnitTesting;
using SettlersOfCatanAnalysis.Objects;

namespace SettlersOfCatanAnalysisTests
{
    [TestClass]
    public class VertexTest
    {
        /// <summary>
        /// Tests upgrading a vertex plot from None to Settlement
        /// </summary>
        [TestMethod]
        public void VertexUpgrade1_1()
        {
            var vertex = new Vertex();
            var result = vertex.UpgradeVertex(Player.Colour.Red);

            var colour = vertex.Colour;
            var plot = vertex.Plot;
            Assert.AreEqual(true, result, "Function returned incorrect result");
            Assert.AreEqual(Player.Colour.Red, colour, "Colour is incorrect");
            Assert.AreEqual(Vertex.Structure.Settlement, plot, "Structure is incorrect");
        }

        /// <summary>
        /// Tests upgrading a vertex plot from Settlement to City
        /// </summary>
        [TestMethod]
        public void VertexUpgrade1_2()
        {
            var vertex = new Vertex(Vertex.Structure.Settlement, Player.Colour.Red);
            var result = vertex.UpgradeVertex(Player.Colour.Red);

            var colour = vertex.Colour;
            var plot = vertex.Plot;
            Assert.AreEqual(true, result, "Function returned incorrect result");
            Assert.AreEqual(Player.Colour.Red, colour, "Colour is incorrect");
            Assert.AreEqual(Vertex.Structure.City, plot, "Structure is incorrect");
        }

        /// <summary>
        /// Tests trying to upgrade a fully upgraded vertex plot
        /// </summary>
        [TestMethod]
        public void VertexUpgrade1_3()
        {
            var vertex = new Vertex(Vertex.Structure.City, Player.Colour.Red);
            var result = vertex.UpgradeVertex(Player.Colour.Red);

            var colour = vertex.Colour;
            var plot = vertex.Plot;
            Assert.AreEqual(false, result, "Function returned incorrect result");
            Assert.AreEqual(Player.Colour.Red, colour, "Colour is incorrect");
            Assert.AreEqual(Vertex.Structure.City, plot, "Structure is incorrect");
        }

        /// <summary>
        /// Tests trying to upgrade a plot from the incorrect player colour
        /// </summary>
        [TestMethod]
        public void VertexUpgrade1_4()
        {
            var vertex = new Vertex(Vertex.Structure.Settlement, Player.Colour.Red);
            var result = vertex.UpgradeVertex(Player.Colour.Blue);

            var colour = vertex.Colour;
            var plot = vertex.Plot;
            Assert.AreEqual(false, result, "Function returned incorrect result");
            Assert.AreEqual(Player.Colour.Red, colour, "Colour is incorrect");
            Assert.AreEqual(Vertex.Structure.Settlement, plot, "Structure is incorrect");
        }
    }
}
