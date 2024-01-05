namespace GraveyardManager.Model
{
    public class Niche : IInterment
    {
        public int Id { get; set; }
        public IList<Person> People { get; set; }

        public IList<Person> RemovedPeople { get; set; }
        public DateTime PaidUntil { get; set; }
        public DateTime PlaceAcquisition { get; set; }


        public Niche()
        {
            People = new List<Person>();
            RemovedPeople = new List<Person>();
        }
    }
}
