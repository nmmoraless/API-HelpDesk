namespace API_HelpDesk.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int IdCargo { get; set; }
        public int IdArea { get; set; }
        public string Password { get; set; }
        public int Estado { get; set; }
        public int Tipo { get; set; }

        public Usuarios(int id, string usuario, string email, string telefono, int idCargo, int idArea, string password, int estado, int tipo)
        {
            Id = id;
            Usuario = usuario;
            Email = email;
            Telefono = telefono;
            IdCargo = idCargo;
            IdArea = idArea;
            Password = password;
            Estado = estado;
            Tipo = tipo;
        }

        public Usuarios()
        {

        }
    }
}
