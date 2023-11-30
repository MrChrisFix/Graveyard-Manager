namespace GraveyardManager.Model
{
    public class Urn
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public DateTime PaidUntil { get; set; }
        public DateTime PlaceAcquisition { get; set; }
        public UrnPosition Position { get; set; }

        public class UrnPosition
        {
            //TODO: more positioning info
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
