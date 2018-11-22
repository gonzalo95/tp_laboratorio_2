using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EntidadesHechas
{
    public static class PaqueteDAO
    {
        static SqlConnection conexion;
        static SqlCommand comando;

        /// <summary>
        /// Agrega un paquete a la base de datos.
        /// </summary>
        /// <param name="p">Paquete a guardar.</param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                comando.CommandText = string.Format("INSERT INTO dbo.Paquetes (direccionEntrega, trackingId, alumno) VALUES ('{0}','{1}','Greco Gonzalo')", p.DireccionEntrega, p.TrackingID);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (SqlException exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Constructor estatico.
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection("Data Source=.;Initial Catalog=correo-sp-2017;Integrated Security=True");
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }
    }
}
