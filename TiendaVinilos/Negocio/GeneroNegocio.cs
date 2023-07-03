using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class GeneroNegocio
    {

        public List<Genero> listar()
        {
            List<Genero> lista = new List<Genero>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id,Descripcion,activo from GENEROS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Genero aux = new Genero();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Genero nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO Generos (Descripcion) VALUES (@Descripcion); SELECT SCOPE_IDENTITY();";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);

                datos.comando.Connection = datos.conexion; // Asignar la conexión al objeto SqlCommand

                datos.conexion.Open(); // Abre la conexión a la base de datos



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void BajaLogica(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE GENEROS set Activo = 0 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el genero.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void AltaLogica(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE GENEROS set Activo = 1 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el genero.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
