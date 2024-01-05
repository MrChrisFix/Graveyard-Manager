
//                N |Plot| 1 - 1 |Grave| 1 - N |Person|
//              /
// |Graveyard| 1
//              \
//                N |Columbarium| 1 - N |Niche| 1 - N |Person|

namespace GraveyardManager.Model
{
    public class Graveyard
    {
        public int Id { get; set; }
        public List<Plot> Plots { get; set; }
        public List<Columbarium> Columbaria { get; set; }

        public GraveyardOwner Owner { get; set; }
        public Address Address { get; set; }

        public Graveyard()
        {
            Owner = new() { Name = "", Address = new() };
            Address = new();
            Plots = new List<Plot>();
            Columbaria = new List<Columbarium>();
        }

        public Graveyard(GraveyardOwner owner, Address address)
        {
            Plots = new List<Plot>();
            Columbaria = new List<Columbarium>();
            Owner = owner;
            Address = address;
        }
    }
}
