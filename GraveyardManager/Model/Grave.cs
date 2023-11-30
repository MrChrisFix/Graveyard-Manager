using System;

namespace GraveyardManager.Model
{
    public class Grave
    {
        public int Id { get; set; }
        public required List<Person> Persons { get; set; }
        public DateOnly PaidUntil { get; set; }
        public DateOnly PlotAcquisition { get; set; }
        public required int UsedPlotId { get; set; }
    }
}
