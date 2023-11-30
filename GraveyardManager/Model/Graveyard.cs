namespace GraveyardManager.Model
{
    public class Graveyard
    {
        public int Id { get; set; }
        public List<Plot> Plots { get; set; }
        public List<Urn> urns { get; set; } //TODO: not urns, but plaes for urns
    }
}
