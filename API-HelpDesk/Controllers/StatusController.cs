using API_HelpDesk.Models;
using Microsoft.AspNetCore.Mvc;
using API_HelpDesk.DAL;
using System.Net;

namespace API_HelpDesk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : Controller
    {
        [HttpGet]
        public IList<StatusTicket> Status()
        {
            TicketDAL ticketDAL = new TicketDAL();
            IList<StatusTicket> resultado = ticketDAL.ListarStatusTicket();
            return resultado;
        }
    }
}
