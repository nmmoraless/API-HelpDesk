namespace API_HelpDesk.Models
{
    public class Ubicacion
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Ubicacion(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Ubicacion()
        {

        }
    }


}
