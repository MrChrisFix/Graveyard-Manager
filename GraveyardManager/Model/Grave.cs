namespace GraveyardManager.Model
{
    public class Grave : IInterment
    {
        public int Id { get; set; }
        public required IList<Person> People { get; set; }
        public DateOnly PaidUntil { get; set; }
        public DateOnly PlotAcquisition { get; set; }
        public int PlotId { get; set; }
    }
}
