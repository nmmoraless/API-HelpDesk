namespace API_HelpDesk.Models
{
    public class StatusTicket
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StatusTicket(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public StatusTicket()
        {

        }
    }
}
