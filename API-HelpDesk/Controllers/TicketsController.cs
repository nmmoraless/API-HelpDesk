using API_HelpDesk.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_HelpDesk.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TicketController : Controller

    {
        IList<NewTicket> TicketList = new List<NewTicket>();
        public TicketController()
        {
            NewTicket Ticket1 = new NewTicket("1", "Administrativa", "Lider 1", "Boyaca", "Garagoa", "Presencia de comején en la oficina", "", new DateTime(2022, 06, 05), "Pendiente");
            NewTicket Ticket2 = new NewTicket("2", "Soporte", "Lider 2", "Bolívar", "Cartagena", "Capacitación del modulo nómina pendinete", "", new DateTime(2022, 06, 05), "Registrar");
            NewTicket Ticket3 = new NewTicket("3", "Tecnología", "Lider 3", "Santander", "Bucaramanga", "Creación de nuevo módulo de tickets", "", new DateTime(2022, 06, 05), "Registrar");
            NewTicket Ticket4 = new NewTicket("4", "Contabilidad", "Lider 2", "Cundinamarca", "Soacha", "Inclusión de campos en formulario de registro", "", new DateTime(2022, 06, 05), "Registrar");

            TicketList.Add(Ticket1);
            TicketList.Add(Ticket2);
            TicketList.Add(Ticket3);
            TicketList.Add(Ticket4);
        }

        [HttpGet]

        public IList<NewTicket> ObtenerData()
        {

            return TicketList;
        }

        [HttpPost]

        public IList<NewTicket> GuardarData([FromBody] NewTicket TicketNew)
        {
            TicketList.Add(TicketNew);

            return TicketList;
        }

        [HttpPut]

        public IList<NewTicket> ActualizarData([FromBody] NewTicket TicketNew, string id)
        {
            int position;
            for (var i = 0; i < TicketList.Count; i++)
            {
                if (TicketList[i].Id == id)
                {
                    position = i;
                    TicketList[i] = TicketNew;

                }
            }
            return TicketList;
        }

        [HttpDelete]

        public IList<NewTicket> DeleteData(string id)
        {
            for (var i = 0; i < TicketList.Count; i++)
            {
                if (TicketList[i].Id == id)
                {
                    TicketList.RemoveAt(i);

                }
            }
            return TicketList;
        }

    }
}
