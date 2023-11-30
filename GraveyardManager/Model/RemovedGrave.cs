using GraveyardManager.Utils;

namespace GraveyardManager.Model
{
    public class RemovedGrave
    {
        public int Id { get; set; }
        public List<Person> Persons { get; set; }
        public int UsedPlotId { get; set; }
        public DateOnly PlotAcquisition { get; set; }
        public DateOnly GraveRemoval { get; set; }

        RemovedGrave() { }

        public RemovedGrave(Grave grave, DateOnly removalDay)
        {
            Persons = grave.Persons;
            UsedPlotId = grave.UsedPlotId;
            PlotAcquisition = grave.PlotAcquisition;
            GraveRemoval = removalDay;
        }
    }
}
