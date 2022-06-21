
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


    }
}