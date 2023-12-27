
//                N |Plot| 1 - 1 |Grave| 1 - N |Person|
//              /
// |Graveyard| 1
//              \
//                N |Columbarium| 1 - N |Niche| 1 - N |Urn| 1 - 1 |Person|

namespace GraveyardManager.Model
{
    public class Graveyard
    {
        public int Id { get; set; }
        public List<Plot> Plots { get; set; }
        //public List<Urn> urns { get; set; } //TODO: not urns, but plaes for urns => Niche/Columbarium

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
