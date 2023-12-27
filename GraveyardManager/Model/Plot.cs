namespace GraveyardManager.Model
{
    public class Plot
    {
        public int Id { get; set; }
        public Grave? Grave { get; set; }

        public PlotSize Size { get; set; }

        // Positioning -> top left corner of plot
        // The coordintes are in meters
        //TODO: changes at enlargement/reduction of cementary
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Angle { get; set; }
        public string? GraveyardPart { get; set; }

        public enum PlotSize
        {
            SINGLE,
            FAMILY
        }
    }
}
