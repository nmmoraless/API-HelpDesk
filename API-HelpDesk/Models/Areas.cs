namespace API_HelpDesk.Models
{
    public class Areas
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Areas(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Areas()
        {

        }
    }
}
