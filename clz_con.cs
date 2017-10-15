using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;


namespace sny
{
    class clz_con
    {

        public static SqlConnection con = new SqlConnection  ("Data Source=ASHAN;Initial Catalog=sql;Integrated Security=True");
    }
}
