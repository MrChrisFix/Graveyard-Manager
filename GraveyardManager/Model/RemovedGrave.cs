namespace GraveyardManager.Model
{
    public class RemovedGrave : IInterment
    {
        public int Id { get; set; }
        public IList<Person> People { get; set; }
        public int PlotId { get; set; }
        public DateOnly PlotAcquisition { get; set; }
        public DateOnly GraveRemoval { get; set; }

        public RemovedGrave() { }

        public RemovedGrave(Grave grave, DateOnly removalDay)
        {
            People = grave.People;
            PlotId = grave.PlotId;
            PlotAcquisition = grave.PlotAcquisition;
            GraveRemoval = removalDay;
        }
    }
}
