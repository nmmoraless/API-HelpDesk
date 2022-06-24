
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
                    string year = TicketNew.Fecha.Year.ToString();
                    int month = TicketNew.Fecha.Month;
                    int day = TicketNew.Fecha.Day;
                    string newDate = year + "-" + (month < 10 ? "0" + month.ToString() : month.ToString()) + "-" + (day < 10 ? "0" + day.ToString() : day.ToString());

                    String sql = $"INSERT INTO [dbo].[TICKETS] ([AREA], [RESPONSABLE], [DEPARTAMENTO], [MUNICIPIO], [DESCRIPCION],[SOLUCION],[FECHA], [ESTADO]) VALUES('{TicketNew.Area}','{TicketNew.Responsable}','{TicketNew.Departamento}','{TicketNew.Municipio}','{TicketNew.Descripcion}','{TicketNew.Solucion}',CONVERT(datetime, '{newDate}'),'{TicketNew.Accion}');";

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
            catch (Exception e)
            {
                return "Fallo";
            }
            return "Lo logre";
        }

        //CONSULTAR TICKETS DE LA BASE DE DATOS

        public IList<NewTicket> ListarTickets(int? id)
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

                    String sql;
                    if (id == 0)
                    {
                        sql = String.Format("SELECT[ID], [AREA], [RESPONSABLE], [DEPARTAMENTO], [MUNICIPIO], [DESCRIPCION], [SOLUCION],[FECHA], [ESTADO] FROM [dbo].[TICKETS];");//String.Format() es opcional
                    }
                    else
                    {
                        sql = String.Format($"SELECT[ID], [AREA], [RESPONSABLE], [DEPARTAMENTO], [MUNICIPIO], [DESCRIPCION], [SOLUCION],[FECHA], [ESTADO] FROM [dbo].[TICKETS] WHERE ID = {id};");//String.Format() es opcional
                    }

                    

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
                                unTicket.Responsable = reader.GetString(2);
                                unTicket.Departamento = reader.GetString(3);
                                unTicket.Municipio = reader.GetString(4);
                                unTicket.Descripcion = reader.GetString(5);
                                unTicket.Solucion = reader.GetString(6);
                                unTicket.Fecha = reader.GetDateTime(7);
                                unTicket.Accion = reader.GetString(8);

                                ListaDeTickets.Add(unTicket);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return ListaDeTickets;
        }

        //ACTUALIZACION DE TICKETS EN LA BASE DE DATOS
        public string UpdateTicket(NewTicket TicketNew, int id)
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
                    string year = TicketNew.Fecha.Year.ToString();
                    int month = TicketNew.Fecha.Month;
                    int day = TicketNew.Fecha.Day;
                    string newDate = year + "-" + (month < 10 ? "0" + month.ToString() : month.ToString()) + "-" + (day < 10 ? "0" + day.ToString() : day.ToString());

                    String sql = $"UPDATE [dbo].[TICKETS] SET [AREA] = '{TicketNew.Area}', [RESPONSABLE] = '{TicketNew.Responsable}', [DEPARTAMENTO] = '{TicketNew.Departamento}', [MUNICIPIO] = '{TicketNew.Municipio}', [DESCRIPCION] = '{TicketNew.Descripcion}', [SOLUCION] = '{TicketNew.Solucion}',[FECHA] = CONVERT(datetime, '{newDate}'), [ESTADO] = '{TicketNew.Accion}' WHERE [ID] = {id};";

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
                return "Falle " + e.Message;
            }
            return "Lo logre";
        }

        //ELIMINACIÓN DE TICKETS EN LA BASE DE DATOS
        public string DeleteTicket( int id)
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

                    String sql = $"DELETE [dbo].[TICKETS] WHERE ID = {id};";

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
                return "Falle " + e.Message;
            }
            return "Lo logre";
        }


    }
}