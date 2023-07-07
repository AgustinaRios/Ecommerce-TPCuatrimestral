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
                datos.setearConsulta("Select Id,Nombre,Activo from ARTISTA ORDER BY Nombre ASC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Artista aux = new Artista();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
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

        public List<Artista> listar(string buscar)
        {
            List<Artista> lista = new List<Artista>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select art.Id,art.Nombre,art.Activo from ARTISTA art inner join ALBUMES a on a.IdArtista=art.Id where a.Activo=1 and art.Activo=1  and Nombre like '%" + buscar + "%'");
                datos.ejecutarLectura();
                

                while (datos.Lector.Read())
                {
                    Artista aux = new Artista();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
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

        public int agregar(Artista nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO ARTISTA (Nombre) VALUES (@Nombre); SELECT SCOPE_IDENTITY();";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", nuevo.Nombre);

                datos.comando.Connection = datos.conexion; // Asignar la conexión al objeto SqlCommand

                datos.conexion.Open(); // Abre la conexión a la base de datos

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

        public void BajaLogica(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTISTA set Activo = 0 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja al artista.", ex);
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
                datos.setearConsulta("UPDATE ARTISTA set Activo = 1 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta al artista.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }

}
