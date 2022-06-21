
using System;
using Microsoft.Data.SqlClient;
using System.Text;
using API_HelpDesk.Models;

namespace API_HelpDesk.DAL
{
    public class TicketDAL
    {

        public TicketDAL()
        {

        }

        //CREACION DE NUEVOS TICKETS EN LA BASE DE DATOS
        public string CrearNuevoTicket(NewTicket TicketNew)
        {
       
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-DQ37319\\LOCALDB";
                builder.UserID = "sa";
                builder.Password = "123456";
                builder.InitialCatalog = "HelpDeskDB";
                builder.TrustServerCertificate = true;
                builder.Encrypt = true;
                builder.IntegratedSecurity = true;
                builder.UserInstance = false;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    String sql = $"INSERT INTO [dbo].[TICKETS] ([AREA], [RESPONSABLE], [DEPARTAMENTO], [MUNICIPIO], [DESCRIPCION], [ESTADO]) VALUES('{TicketNew.Area}','{TicketNew.Responsable}','{TicketNew.Departamento}','{TicketNew.Municipio}','{TicketNew.Descripcion}','{TicketNew.Accion}');";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            /*while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }*/
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                return "Falle "+e.Message;
            }
            return "Lo logre";
        }

        //CONSULTAR TICKETS DE LA BASE DE DATOS

        public IList<NewTicket> ListarTickets()
        {
            IList<NewTicket> ListaDeTickets = new List<NewTicket>();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-DQ37319\\LOCALDB";
                builder.UserID = "sa";
                builder.Password = "123456";
                builder.InitialCatalog = "HelpDeskDB";
                builder.TrustServerCertificate = true;
                builder.Encrypt = true;
                builder.IntegratedSecurity = true;
                builder.UserInstance = false;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    String sql = String.Format("SELECT[ID], [AREA], [MUNICIPIO], [DESCRIPCION], [RESPONSABLE], [ESTADO] FROM[dbo].[TICKETS];");//String.Format es opcional

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NewTicket unTicket = new NewTicket();
                                unTicket.Id = reader.GetInt32(0);
                                unTicket.Area = reader.GetString(1);
                                unTicket.Municipio = reader.GetString(2);
                                unTicket.Descripcion = reader.GetString(3);
                                unTicket.Responsable = reader.GetString(4);
                                unTicket.Accion = reader.GetString(5);

                                ListaDeTickets.Add(unTicket);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
               
            }
            return ListaDeTickets;
        }


    }
}