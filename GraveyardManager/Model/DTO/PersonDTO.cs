namespace GraveyardManager.Model.DTO
{
    public record PersonDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateOnly? Birth { get; set; }

        public DateOnly? Death { get; set; }

        public DateOnly? Ordained { get; set; }
        public DateTime? Funeral { get; set; }
    }
}
