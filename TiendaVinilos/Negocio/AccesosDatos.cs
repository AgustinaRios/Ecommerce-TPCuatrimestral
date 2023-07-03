using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Negocio
{
    public class AccesoDatos
    {

        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader lector;


        public AccesoDatos()
        {

            conexion = new SqlConnection("data source=.\\SQLEXPRESS; initial catalog=ECOMMERCE_TP_DB; integrated security=true");
            comando = new SqlCommand();
        }



        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void setearProcedimiento(string nombreProcedimiento)
        {
            comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreProcedimiento;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (lector != null && !lector.IsClosed)
            {
                lector.Close();
            }

            if (conexion != null && conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }
        }


        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public void ejectutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public int ejectutarAccionScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
              return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }



    }
}
