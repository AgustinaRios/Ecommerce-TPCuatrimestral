using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArtistaNegocio
    {

        public List<Artista> listar()
        {
            List<Artista> lista = new List<Artista>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id,Nombre from ARTISTA");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Artista aux = new Artista();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

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

        public int agregar(Artista nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO ARTISTA (Nombre) VALUES (@Nombre); SELECT SCOPE_IDENTITY();";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", nuevo.Nombre);
              

                int idArtista = Convert.ToInt32(datos.comando.ExecuteScalar());

                // Asignar el ID generado al objeto Artista
                nuevo.Id = idArtista;

                return idArtista;
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

        public Artista ObtenerArtistaPorNombre(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT Id, Nombre FROM Artista WHERE Nombre = @Nombre";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", nombre);

                datos.ejecutarLectura(); // Agregar esta línea para abrir la conexión y ejecutar la consulta

                if (datos.Lector.Read())
                {
                    Artista artista = new Artista();
                    artista.Id = datos.Lector.GetInt32(0);
                    artista.Nombre = datos.Lector.GetString(1);

                    return artista;
                }
                else
                {
                    return null;
                }
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





    }

}
