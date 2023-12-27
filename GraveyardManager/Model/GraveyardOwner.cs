namespace GraveyardManager.Model
{
    public class GraveyardOwner
    {
        public required string Name { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public required Address Address { get; set; }
    }
}
