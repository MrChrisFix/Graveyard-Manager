namespace GraveyardManager.Model
{
    public class Plot
    {
        public int Id { get; set; }
        public Grave? Grave { get; set; }

        public PlotSize Size { get; set; }

        //Positioning
        public int X { get; set; }
        public int Y { get; set; }
        public string? GraveyardPart { get; set; }

        public enum PlotSize
        {
            SINGLE,
            FAMILY
        }
    }
}
