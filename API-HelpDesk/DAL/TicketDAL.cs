
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
                builder.DataSource = "DESKTOP-PI5Q8IN\\SQLEXPRESS";//"DESKTOP-DQ37319\\LOCALDB";
                builder.UserID = "sa";
                builder.Password = "09022022*";//"123456";
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

                    String sql = $"INSERT INTO [dbo].[TICKETS] ([AREA], [USUARIO], [DEPARTAMENTO], [MUNICIPIO], [DESCRIPCION],[SOLUCION],[FECHA],[ESTADO]) VALUES ({TicketNew.Area},{TicketNew.Usuario},{TicketNew.Departamento},{TicketNew.Municipio},'{TicketNew.Descripcion}','{TicketNew.Solucion}',CONVERT(datetime, '{newDate}'),CONVERT(int,'{TicketNew.Accion}'));";

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

        //CONSULTAR TICKETS

        public IList<Ticket> ListarTickets(int? id)
        {
            IList<Ticket> ListaDeTickets = new List<Ticket>();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-PI5Q8IN\\SQLEXPRESS";//"DESKTOP-DQ37319\\LOCALDB";
                builder.UserID = "sa";
                builder.Password = "09022022*";//"123456";
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
                        sql = String.Format("SELECT [dbo].[TICKETS].ID, [dbo].[AREAS].[AREA], CONCAT([dbo].[USUARIOS].NOMBRE,' ',[dbo].[USUARIOS].APELLIDOS) AS 'USUARIO', [dbo].[DEPARTAMENTOS].DEPARTAMENTO, [dbo].[MUNICIPIOS].[MUNICIPIO] [MUNICIPIO], [dbo].[TICKETS].[DESCRIPCION], [dbo].[TICKETS].SOLUCION, [dbo].[TICKETS].FECHA, [dbo].[ESTADO_TICKET].ESTADO FROM[dbo].[TICKETS] INNER JOIN[dbo].[AREAS] ON[dbo].[TICKETS].AREA = [dbo].[AREAS].ID INNER JOIN[dbo].[USUARIOS] ON[dbo].[TICKETS].USUARIO = [dbo].[USUARIOS].ID   INNER JOIN[dbo].[DEPARTAMENTOS] ON[dbo].[TICKETS].DEPARTAMENTO = [dbo].[DEPARTAMENTOS].ID INNER JOIN[dbo].[MUNICIPIOS] ON[dbo].[TICKETS].MUNICIPIO = [dbo].[MUNICIPIOS].ID INNER JOIN[dbo].[ESTADO_TICKET] ON[dbo].[TICKETS].ESTADO = [dbo].[ESTADO_TICKET].ID");//String.Format() es opcional
                    }
                    else
                    {
                        sql = String.Format($"SELECT [dbo].[TICKETS].ID, [dbo].[AREAS].[AREA], CONCAT([dbo].[USUARIOS].NOMBRE,' ',[dbo].[USUARIOS].APELLIDOS) AS 'USUARIO', [dbo].[DEPARTAMENTOS].DEPARTAMENTO, [dbo].[MUNICIPIOS].[MUNICIPIO] [MUNICIPIO], [dbo].[TICKETS].[DESCRIPCION], [dbo].[TICKETS].SOLUCION, [dbo].[TICKETS].FECHA, [dbo].[ESTADO_TICKET].ESTADO FROM[dbo].[TICKETS] INNER JOIN[dbo].[AREAS] ON[dbo].[TICKETS].AREA = [dbo].[AREAS].ID INNER JOIN[dbo].[USUARIOS] ON[dbo].[TICKETS].USUARIO = [dbo].[USUARIOS].ID   INNER JOIN[dbo].[DEPARTAMENTOS] ON[dbo].[TICKETS].DEPARTAMENTO = [dbo].[DEPARTAMENTOS].ID INNER JOIN[dbo].[MUNICIPIOS] ON[dbo].[TICKETS].MUNICIPIO = [dbo].[MUNICIPIOS].ID INNER JOIN[dbo].[ESTADO_TICKET] ON[dbo].[TICKETS].ESTADO = [dbo].[ESTADO_TICKET].ID WHERE[dbo].[TICKETS].ID = {id};");//String.Format() es opcional
                    }



                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Ticket searchTicket = new Ticket();
                                searchTicket.Id = reader.GetInt32(0);
                                searchTicket.Area = reader.GetString(1);
                                searchTicket.Usuario = reader.GetString(2);
                                searchTicket.Departamento = reader.GetString(3);
                                searchTicket.Municipio = reader.GetString(4);
                                searchTicket.Descripcion = reader.GetString(5);
                                searchTicket.Solucion = reader.GetString(6);
                                searchTicket.Fecha = reader.GetDateTime(7);
                                searchTicket.Accion = reader.GetString(8);

                                ListaDeTickets.Add(searchTicket);
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

        //ACTUALIZACION DE TICKETS
        public string UpdateTicket(Ticket UpdTicket, int id)
        {

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-PI5Q8IN\\SQLEXPRESS";//"DESKTOP-DQ37319\\LOCALDB";
                builder.UserID = "sa";
                builder.Password = "09022022*";//"123456";
                builder.InitialCatalog = "HelpDeskDB";
                builder.TrustServerCertificate = true;
                builder.Encrypt = true;
                builder.IntegratedSecurity = true;
                builder.UserInstance = false;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string year = UpdTicket.Fecha.Year.ToString();
                    int month = UpdTicket.Fecha.Month;
                    int day = UpdTicket.Fecha.Day;
                    string newDate = year + "-" + (month < 10 ? "0" + month.ToString() : month.ToString()) + "-" + (day < 10 ? "0" + day.ToString() : day.ToString());

                    String sql = $"UPDATE [dbo].[TICKETS] SET [AREA] = [dbo].[AREAS].[ID], [USUARIO] = [dbo].[USUARIOS].[ID], [DESCRIPCION] = '{UpdTicket.Descripcion}', [SOLUCION] = '{UpdTicket.Solucion}', [FECHA] = CONVERT(datetime, '{newDate}'),[ESTADO] = [dbo].[ESTADO_TICKET].[ID] FROM [dbo].[TICKETS] INNER JOIN [dbo].[AREAS] ON [dbo].[AREAS].[AREA] = '{UpdTicket.Area}' INNER JOIN [dbo].[USUARIOS] ON CONCAT([dbo].[USUARIOS].[NOMBRE],' ',[dbo].[USUARIOS].[APELLIDOS]) = '{UpdTicket.Usuario}' INNER JOIN [dbo].[ESTADO_TICKET] ON[dbo].[ESTADO_TICKET].[ESTADO] = '{UpdTicket.Accion}' WHERE[dbo].[TICKETS].[ID] = {id};";

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
                builder.DataSource = "DESKTOP-PI5Q8IN\\SQLEXPRESS";//"DESKTOP-DQ37319\\LOCALDB";
                builder.UserID = "sa";
                builder.Password = "09022022*";//"123456";
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

        //CONSULTAR DEPARTAMENTOS y MUNICIPIOS
        public IList<Ubicacion> ListarUbicaciones(int? id)
        {
            IList<Ubicacion> ListUbicaciones = new List<Ubicacion>();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-PI5Q8IN\\SQLEXPRESS";//"DESKTOP-DQ37319\\LOCALDB";
                builder.UserID = "sa";
                builder.Password = "09022022*";//"123456";
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
                        sql = String.Format("SELECT ID, DEPARTAMENTO FROM [dbo].[DEPARTAMENTOS];");//String.Format() es opcional
                    }
                    else
                    {
                        sql = String.Format($"SELECT ID, MUNICIPIO FROM [dbo].[MUNICIPIOS] WHERE ID_DEPARTAMENTO = {id};");//String.Format() es opcional
                    }

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Ubicacion ubicaciones = new Ubicacion();
                                ubicaciones.Id = reader.GetInt32(0);
                                ubicaciones.Name = reader.GetString(1);

                                ListUbicaciones.Add(ubicaciones);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return ListUbicaciones;
        }

        //CONSULTAR AREAS
        public IList<Areas> ListarAreas()
        {
            IList<Areas> ListAreas = new List<Areas>();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-PI5Q8IN\\SQLEXPRESS";//"DESKTOP-DQ37319\\LOCALDB";
                builder.UserID = "sa";
                builder.Password = "09022022*";//"123456";
                builder.InitialCatalog = "HelpDeskDB";
                builder.TrustServerCertificate = true;
                builder.Encrypt = true;
                builder.IntegratedSecurity = true;
                builder.UserInstance = false;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    String sql;

                    sql = String.Format("SELECT ID, AREA FROM [dbo].[AREAS]");//String.Format() es opcional

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Areas area = new Areas();
                                area.Id = reader.GetInt32(0);
                                area.Name = reader.GetString(1);

                                ListAreas.Add(area);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return ListAreas;
        }

        //CONSULTAR ESTADO DE TICKETS

        public IList<StatusTicket> ListarStatusTicket()
        {
            IList<StatusTicket> ListStatus = new List<StatusTicket>();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-PI5Q8IN\\SQLEXPRESS";//"DESKTOP-DQ37319\\LOCALDB";
                builder.UserID = "sa";
                builder.Password = "09022022*";//"123456";
                builder.InitialCatalog = "HelpDeskDB";
                builder.TrustServerCertificate = true;
                builder.Encrypt = true;
                builder.IntegratedSecurity = true;
                builder.UserInstance = false;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    String sql;

                    sql = String.Format("SELECT ID, ESTADO FROM [dbo].[ESTADO_TICKET]");//String.Format() es opcional

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StatusTicket estado = new StatusTicket();
                                estado.Id = reader.GetInt32(0);
                                estado.Name = reader.GetString(1);

                                ListStatus.Add(estado);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return ListStatus;
        }

        //CONSULTAR USUARIOS

        public IList<Usuarios> ListarUsuarios()
        {
            IList<Usuarios> ListUsers = new List<Usuarios>();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-PI5Q8IN\\SQLEXPRESS";//"DESKTOP-DQ37319\\LOCALDB";
                builder.UserID = "sa";
                builder.Password = "09022022*";//"123456";
                builder.InitialCatalog = "HelpDeskDB";
                builder.TrustServerCertificate = true;
                builder.Encrypt = true;
                builder.IntegratedSecurity = true;
                builder.UserInstance = false;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    String sql;

                    sql = String.Format("SELECT ID, CONCAT(NOMBRE,' ',APELLIDOS) AS USUARIO FROM [dbo].[USUARIOS]");//String.Format() es opcional

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Usuarios user = new Usuarios();
                                user.Id = reader.GetInt32(0);
                                user.Usuario = reader.GetString(1);

                                ListUsers.Add(user);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return ListUsers;
        }



    }
}