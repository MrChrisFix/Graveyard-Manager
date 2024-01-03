namespace GraveyardManager.Model
{
    public class RemovedGrave : IInterment
    {
        public int Id { get; set; }
        public IEnumerable<Person> People { get; set; }
        public int UsedPlotId { get; set; }
        public DateOnly PlotAcquisition { get; set; }
        public DateOnly GraveRemoval { get; set; }

        RemovedGrave() { }

        public RemovedGrave(Grave grave, DateOnly removalDay)
        {
            People = grave.People;
            UsedPlotId = grave.Plot.Id;
            PlotAcquisition = grave.PlotAcquisition;
            GraveRemoval = removalDay;
        }
    }
}
