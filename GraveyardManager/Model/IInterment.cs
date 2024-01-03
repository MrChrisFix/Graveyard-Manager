namespace GraveyardManager.Model
{
    public interface IInterment
    {
        public IEnumerable<Person> People { get; set; }
    }
}
