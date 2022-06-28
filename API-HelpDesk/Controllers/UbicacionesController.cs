using API_HelpDesk.Models;
using Microsoft.AspNetCore.Mvc;
using API_HelpDesk.DAL;
using System.Net;

namespace API_HelpDesk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UbicacionesController : Controller
    {
        [HttpGet]
        public IList<Ubicacion> Ubicaciones(int? id)
        {
            TicketDAL ticketDAL = new TicketDAL();
            IList<Ubicacion> resultado = ticketDAL.ListarUbicaciones(id);
            return resultado;
        }
    }
}
