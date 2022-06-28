using API_HelpDesk.Models;
using Microsoft.AspNetCore.Mvc;
using API_HelpDesk.DAL;
using System.Net;

namespace API_HelpDesk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        [HttpGet]
        public IList<Usuarios> Status()
        {
            TicketDAL ticketDAL = new TicketDAL();
            IList<Usuarios> resultado = ticketDAL.ListarUsuarios();
            return resultado;
        }
    }
}
