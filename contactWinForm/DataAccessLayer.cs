using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace contactWinForm
{
    class DataAccessLayer
    {
        static string conexName = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Contacts;Data Source=DESKTOP-VBU73D2\\SQLEXPRESS";
        private SqlConnection conexion = new SqlConnection(conexName);
    }
}
