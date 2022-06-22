﻿
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

                    String sql = $"INSERT INTO [dbo].[TICKETS] ([AREA], [RESPONSABLE], [DEPARTAMENTO], [MUNICIPIO], [DESCRIPCION],[SOLUCION], [ESTADO]) VALUES('{TicketNew.Area}','{TicketNew.Responsable}','{TicketNew.Departamento}','{TicketNew.Municipio}','{TicketNew.Descripcion}','{TicketNew.Solucion}','{TicketNew.Accion}');";

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

                    String sql = String.Format("SELECT[ID], [AREA], [RESPONSABLE], [DEPARTAMENTO], [MUNICIPIO], [DESCRIPCION], [SOLUCION], [ESTADO] FROM [dbo].[TICKETS];");//String.Format() es opcional

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
                                unTicket.Accion = reader.GetString(7);

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

                    String sql = $"UPDATE [dbo].[TICKETS] SET [AREA] = '{TicketNew.Area}', [RESPONSABLE] = '{TicketNew.Responsable}', [DEPARTAMENTO] = '{TicketNew.Departamento}', [MUNICIPIO] = '{TicketNew.Municipio}', [DESCRIPCION] = '{TicketNew.Descripcion}', [SOLUCION] = '{TicketNew.Solucion}', [ESTADO] = '{TicketNew.Accion}' WHERE [ID] = {id};";

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