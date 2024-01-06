namespace GraveyardManager.Model
{
    public class Grave
    {
        public int Id { get; set; }
        public IList<Person> People { get; set; } = new List<Person>();
        public DateOnly PaidUntil { get; set; }
        public DateOnly PlotAcquisition { get; set; }
        public int PlotId { get; set; }
    }
}
