namespace GraveyardManager.Model
{
    public class Niche
    {
        public int Id { get; set; }
        public IList<Person> People { get; set; }

        public IList<Person> RemovedPeople { get; set; }
        public DateOnly PaidUntil { get; set; }
        public DateOnly PlaceAcquisition { get; set; }


        public Niche()
        {
            People = new List<Person>();
            RemovedPeople = new List<Person>();
        }
    }
}
