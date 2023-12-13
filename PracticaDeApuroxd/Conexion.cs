using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PracticaDeApuroxd
{
    internal class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=DESKTOP-NOFQN3B;DATABASE=REGISTROS;integrated security=true;");
            cn.Open();
            return cn;
        }
    }
}
