namespace GraveyardManager.Model
{
    public class Niche
    {
        public int Id { get; set; }
        public IEnumerable<Person> People { get; set; }

        public IEnumerable<Person> RemovedPeople { get; set; }
        public DateTime PaidUntil { get; set; }
        public DateTime PlaceAcquisition { get; set; }


        public Niche()
        {
            People = new List<Person>();
            RemovedPeople = new List<Person>();
        }
    }
}
