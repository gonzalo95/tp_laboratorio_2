using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EntidadesHechas
{
    public class PaqueteDAO
    {
        public bool Insertar(Paquete p)
        {
            SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=correo-sp-2017;Integrated Security=True");
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
            comando.CommandText = string.Format("INSERT INTO dbo.Paquetes (direccionEntrega, trackingId, alumno) VALUES ('{0}','{1}','Greco Gonzalo')", p.DireccionEntrega, p.TrackingID);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            return true;
        }

        public PaqueteDAO() { }
    }
}
