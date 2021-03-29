using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB_Prog_WPF.Models
{
    class ConnectionMSSQL
    {
        public SqlConnection conn;
        public ConnectionMSSQL() 
        {
            conn = new SqlConnection(Properties.Settings.Default.consting);
        }

    }
}
