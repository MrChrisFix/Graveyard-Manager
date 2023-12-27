namespace GraveyardManager.Model
{
    public class Graveyard
    {
        public int Id { get; set; }
        public List<Plot> Plots { get; set; }
        //public List<Urn> urns { get; set; } //TODO: not urns, but plaes for urns => Niche

        public GraveyardOwner Owner { get; set; } //City, parish, other?
        public Address Address { get; set; }

        public Graveyard()
        {
            Owner = new() { Name = "", Address = new() };
            Address = new();
            Plots = new List<Plot>();
        }

        public Graveyard(GraveyardOwner owner, Address address)
        {
            Plots = new();
            Owner = owner;
            Address = address;
        }
    }
}
