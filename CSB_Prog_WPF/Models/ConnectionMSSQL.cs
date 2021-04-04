using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSB_Prog_WPF.Models
{
    class ConnectionMSSQL
    {
        public SqlConnection conn;
        public SqlCommand cmdSql;
        public ConnectionMSSQL() 
        {
            conn = new SqlConnection();
            conn.ConnectionString = Properties.Settings.Default.consting;
            cmdSql = new SqlCommand();
            cmdSql.Connection = conn;
        }

        public DataTable getInDataTable(string sqlRequest) 
        {
            /*try
            {*/
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = cmdSql;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sqlRequest;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    cmd.Dispose();
                    DataTable dt = new DataTable();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        dt.Columns.Add(new DataColumn(rdr.GetName(i), rdr.GetFieldType(i)));                // запись названий колонок в объект datatable
                    }

                    if (rdr.HasRows)
                    {
                        
                        while (rdr.Read())
                        {
                            DataRow rec = dt.NewRow();
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                rec[i] = rdr.GetValue(i);                                                   // запись данных в объект datatable
                            }
                            dt.Rows.Add(rec);
                        }
                    }
                    rdr.Close();
                    return dt;
                }
            /*}
            catch (SqlException ex) 
            {
                return null;
            }*/
        } 
    }
}
