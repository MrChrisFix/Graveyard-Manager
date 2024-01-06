using System.Collections.Immutable;

namespace GraveyardManager.Model
{
    public class Columbarium
    {
        public int Id { get; set; }

        public IList<Niche> Niches { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }

        // Positioning -> top left corner of plot
        // The coordintes are in meters
        //TODO: changes at enlargement/reduction of cementary
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Angle { get; set; }
        public string? GraveyardPart { get; set; }

        public Graveyard Graveyard { get; set; } = null!;

        public Columbarium(int id, int height, int width, decimal x, decimal y, decimal angle, string? graveyardPart, Graveyard graveyard)
        {
            Id = id;
            Height = height;
            Width = width;
            X = x;
            Y = y;
            Angle = angle;
            GraveyardPart = graveyardPart;
            Graveyard = graveyard;
            Niches = new List<Niche>(new Niche[width*height]);
        }
    }
}
