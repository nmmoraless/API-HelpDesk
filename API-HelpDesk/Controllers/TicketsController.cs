using API_HelpDesk.Models;
using Microsoft.AspNetCore.Mvc;
using API_HelpDesk.DAL;
using System.Net;

namespace API_HelpDesk.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TicketController : Controller

    {
        IList<NewTicket> TicketList = new List<NewTicket>();
        public TicketController()
        {

        }

        [HttpGet]

        public IList<Ticket> ObtenerData(int? id)
        {
            TicketDAL ticketDAL = new TicketDAL();
            IList<Ticket> resultado = ticketDAL.ListarTickets(id);
            return resultado;
        }

        [HttpPost]

        public HttpResponseMessage GuardarData([FromBody] NewTicket TicketNew)
        {
            HttpResponseMessage res;
            try
            {
                //Instaciar conexión a base de datos
                TicketDAL ticketDAL = new TicketDAL();
                string newTicket = ticketDAL.CrearNuevoTicket(TicketNew);
                res = new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            return res;
        }

        [HttpPut]

        public HttpResponseMessage ActualizarData([FromBody] Ticket UpdTicket, int id) //Tipo de dato respuesta HTTP
        {
            HttpResponseMessage res;
            try
            {
                //Instaciar conexión a base de datos
                TicketDAL ticketDAL = new TicketDAL();
                string Ticket = ticketDAL.UpdateTicket(UpdTicket, id);
                res = new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            return res;

        }

        [HttpDelete]

        public HttpResponseMessage DeleteData(int id)
        {
            HttpResponseMessage res;
            try
            {
                //Instaciar conexión a base de datos
                TicketDAL ticketDAL = new TicketDAL();
                string newTicket = ticketDAL.DeleteTicket(id);
                res = new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            return res;
        }


    }
}
