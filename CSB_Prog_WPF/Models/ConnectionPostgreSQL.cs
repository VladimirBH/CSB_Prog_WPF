using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB_Prog_WPF.Models
{
    class ConnectionPostgreSQL
    {
        public NpgsqlConnection conn;
        public ConnectionPostgreSQL() 
        {
            string connstring = "Server=localhost;Port=5432;User Id=vladimirbh;" +
            "Password=248517;Database=CSB;";
            conn = new NpgsqlConnection(connstring);
        }

    }
}
