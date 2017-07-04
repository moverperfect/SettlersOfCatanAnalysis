namespace SettlersOfCatanAnalysis.Objects
{
    public class Edge
    {
        internal bool IsRoad { get; set; }

        internal Player.Colour Colour { get; set; }

        internal Edge()
        {
            Colour = Player.Colour.None;
            IsRoad = false;
        }
    }
}
