using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace QLHV
{
    internal class DataConnection
    {
        string conStr;

        public DataConnection()
        {
            //conStr = "Data Source =  LAPTOP-VLK11DLH\\SQLEXPRESS; initial catalog = QLHV; Integrated Security= true";
            conStr = @"Data Source =  LAPTOP-VLK11DLH\SQLEXPRESS; initial catalog = QLHV; Integrated Security= true";
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(conStr);
        }
    }
}
