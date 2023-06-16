using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AlbumNegocio
    {
        public List<Album> listar()
        {
            List<Album> lista = new List<Album>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select A.Id,Titulo,Artista,FechaLanzamiento,ImgTapa,ImgContratapa,G.Descripcion from ALBUMES A inner join GENEROS G on  G.Id=A.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Album aux = new Album();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Artista = (string)datos.Lector["Artista"];
                    aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.ImgTapa = (string)datos.Lector["ImgTapa"];
                    aux.ImgContratapa = (string)datos.Lector["ImgContratapa"];
                    //aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    
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

        public void agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values( '" + nuevo.Descripcion + "')";
                datos.setearConsulta("insert into  CATEGORIAS (Descripcion) " + valores);

                datos.ejectutarAccion();

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

        public void EliminarFisico(Int32 Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete from GENEROS where Id = @id");
                datos.setearParametro("@id", Id);
                datos.ejectutarAccion();
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

