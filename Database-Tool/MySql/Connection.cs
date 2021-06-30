using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Database_Tool.MySql
{
    class Connection
    {

        public static MySqlConnection connMaster = new MySqlConnection();

        public static MySqlConnection dataSource(string svw, string dbw, string userw, string passw)
        {
            connMaster = new MySqlConnection($"server={svw}; database={dbw}; Uid={userw}; password={passw};");
            return connMaster;
        }      

        public void Open()
        {
           connMaster.Open();
        }

        public void Close()
        {
            connMaster.Close();
        }
    }
}
