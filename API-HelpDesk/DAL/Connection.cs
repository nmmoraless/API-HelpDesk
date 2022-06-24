using Microsoft.Data.SqlClient;

namespace API_HelpDesk.DAL
{
    public class Connection
    {
        SqlConnection connec;

        public Connection()
        {
            connec = new SqlConnection("Server = DESKTOP - DQ37319\\LOCALDB; Database = HelpDeskDB; Integrated Security = true; User id = sa; Password = 123456; Trust Server Certificate = true; Encrypt = true; User Instance = false");
        }

        public SqlConnection ConnecDB()
        {
            try
            {
                connec.Open();
                return connec;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool DissableDB()
        {
            try
            {
                connec.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
