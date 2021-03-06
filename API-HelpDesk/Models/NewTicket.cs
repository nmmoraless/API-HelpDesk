namespace API_HelpDesk.Models
{
    public class NewTicket
    {
        public int Id { get; set; }
        public int Area { get; set; }
        public int Usuario { get; set; }
        public int Departamento { get; set; }
        public int Municipio { get; set; }
        public string Descripcion { get; set; }
        public string? Solucion { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }

        public NewTicket(int id, int area, int usuario, int departamento, int municipio, string descripcion, string solucion, DateTime fecha, string accion)
        {
            Id = id;
            Area = area;
            Usuario = usuario;
            Departamento = departamento;
            Municipio = municipio;
            Descripcion = descripcion;
            Solucion = solucion;
            Fecha = fecha;
            Accion = accion;
        }

        public NewTicket()
        {

        }
    }
}
