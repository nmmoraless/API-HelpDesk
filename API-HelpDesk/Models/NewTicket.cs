namespace API_HelpDesk.Models
{
    public class NewTicket
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string Responsable { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Descripcion { get; set; }
        public string? Solucion { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }

        public NewTicket(int id, string area, string responsable, string departamento, string municipio, string descripcion, string solucion, DateTime fecha, string accion)
        {
            Id = id;
            Area = area;
            Responsable = responsable;
            Departamento = departamento;
            Municipio = municipio;
            Descripcion = descripcion;
            Solucion = solucion;
            Fecha = fecha;
            Accion = accion;
        }
    }
}
