using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonatrach_Pointage_New.Classe
{
    internal class sqlhelper
    {
        SqlConnection cn;
        public sqlhelper(string connectionString)
        {
            cn = new SqlConnection(connectionString);
        }
        public bool IsConection
        {
            get
            {
                if (cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
                return true;
            }
        }
    }
}
