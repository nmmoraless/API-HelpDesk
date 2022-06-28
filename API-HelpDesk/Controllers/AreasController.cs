using API_HelpDesk.Models;
using Microsoft.AspNetCore.Mvc;
using API_HelpDesk.DAL;
using System.Net;

namespace API_HelpDesk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreasController : Controller
    {
        [HttpGet]
        public IList<Areas> Area()
        {
            TicketDAL ticketDAL = new TicketDAL();
            IList<Areas> resultado = ticketDAL.ListarAreas();
            return resultado;
        }
    }
}
