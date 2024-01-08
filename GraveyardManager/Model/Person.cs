using GraveyardManager.Model.DTO;

namespace GraveyardManager.Model
{
    public class Person
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public DateOnly Birth { get; set; }

        public DateOnly Death { get; set; }

        public DateOnly? Ordained { get; set; } //Only for priests and other clergy
        public DateTime? Funeral { get; set; }

        public int GraveId { get; set; }

        public int PlotId { get; set; }

        public void Update(PersonDTO dto)
        {
            FirstName = dto.FirstName ?? FirstName;
            LastName = dto.LastName ?? LastName;
            Birth = dto.Birth ?? Birth;
            Death = dto.Death ?? Death;
            Ordained = dto.Ordained ?? Ordained;
            Funeral = dto.Funeral ?? Funeral;
        }
    }
}
