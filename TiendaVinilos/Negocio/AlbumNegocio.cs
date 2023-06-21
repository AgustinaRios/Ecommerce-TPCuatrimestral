using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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
                datos.setearConsulta("select A.Id, A.Titulo, Art.Id, Art.Nombre as Artista, A.FechaLanzamiento, A.ImgTapa, A.ImgContratapa,A.Activo, G.Id, G.Descripcion as Genero, C.Id,A.Precio, C.Descripcion as Categoria from ALBUMES A, GENEROS G, ARTISTA Art, CATEGORIA C where  G.Id=A.IdGenero and  Art.Id=A.IdArtista and C.Id=a.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Album aux = new Album();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Artista = new Artista();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Artista"))))
                    aux.Artista.Nombre = (string)datos.Lector["Artista"];
                    aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.ImgTapa = (string)datos.Lector["ImgTapa"];
                    aux.ImgContratapa = (string)datos.Lector["ImgContratapa"];
                    aux.Genero = new Genero();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Genero"))))
                        aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Categoria = new Categoria();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Categoria"))) )
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Precio"))))
                    {
                        decimal DosDecimal;
                        DosDecimal = (decimal)datos.Lector["Precio"];
                        aux.Precio = Decimal.Parse(DosDecimal.ToString("0.00"));
                    }

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

        public List<Album> listarxGenero(int idgenero)
        {
            List<Album> lista = new List<Album>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select A.Id, A.Titulo, Art.Id, Art.Nombre as Artista, A.FechaLanzamiento, A.ImgTapa, A.ImgContratapa,A.Activo, G.Id, G.Descripcion as Genero, C.Id,A.Precio, C.Descripcion as Categoria from ALBUMES A, GENEROS G, ARTISTA Art, CATEGORIA C where  G.Id=A.IdGenero and  Art.Id=A.IdArtista and C.Id=a.IdCategoria and A.IdGenero=" + idgenero);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Album aux = new Album();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Artista = new Artista();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Artista"))))
                        aux.Artista.Nombre = (string)datos.Lector["Artista"];
                    aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.ImgTapa = (string)datos.Lector["ImgTapa"];
                    aux.ImgContratapa = (string)datos.Lector["ImgContratapa"];
                    aux.Genero = new Genero();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Genero"))))
                        aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Categoria = new Categoria();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Categoria"))))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Precio"))))
                    {
                        decimal DosDecimal;
                        DosDecimal = (decimal)datos.Lector["Precio"];
                        aux.Precio = Decimal.Parse(DosDecimal.ToString("0.00"));
                    }

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
        public void agregar(Album nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO ALBUMES (Titulo, IdArtista, FechaLanzamiento, ImgTapa, ImgContratapa, IdGenero, IdCategoria, Precio) " +
                                  "VALUES (@Titulo, @IdArtista, @FechaLanzamiento, @ImgTapa, @ImgContratapa, @IdGenero, @IdCategoria, @Precio)";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Titulo", nuevo.Titulo);
                datos.setearParametro("@IdArtista", nuevo.Artista.Id);
                datos.setearParametro("@FechaLanzamiento", nuevo.FechaLanzamiento);
                datos.setearParametro("@ImgTapa", nuevo.ImgTapa);
                datos.setearParametro("@ImgContratapa", nuevo.ImgContratapa);
                datos.setearParametro("@IdGenero", nuevo.Genero.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@Precio", nuevo.Precio);

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
        public void modificarConSP(Album nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearProcedimiento("sp_modificarAlbum");
                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@Titulo", nuevo.Titulo);
                datos.setearParametro("@IdArtista", nuevo.Artista.Id);
                datos.setearParametro("@FechaLanzamiento", nuevo.FechaLanzamiento);
                datos.setearParametro("@ImgTapa", nuevo.ImgTapa);
                datos.setearParametro("@ImgContratapa", nuevo.ImgContratapa);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@IdGenero", nuevo.Genero.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);

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


        
        public Album ObtenerAlbum(Int32 id)
        {
            Album aux = new Album();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select A.Id, A.Titulo, Art.Id, Art.Nombre as Artista, A.FechaLanzamiento, A.ImgTapa, A.ImgContratapa, G.Id, G.Descripcion as Genero, C.Id,A.Precio, C.Descripcion as Categoria from ALBUMES A, GENEROS G, ARTISTA Art, CATEGORIA C where  G.Id=A.IdGenero and  Art.Id=A.IdArtista and C.Id=a.IdCategoria and A.Id=" + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {


                    aux.Id = (Int32)datos.Lector["Id"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("titulo"))))
                        aux.Titulo = (string)datos.Lector["titulo"];

                    aux.Artista = new Artista();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Artista"))))
                        aux.Artista.Nombre = (string)datos.Lector["Artista"];


                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("FechaLanzamiento"))))
                        aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("ImgTapa"))))
                        aux.ImgTapa = (string)datos.Lector["ImgTapa"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("ImgContratapa"))))
                        aux.ImgContratapa = (string)datos.Lector["ImgContratapa"];

                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Precio"))))
                    {
                        decimal DosDecimal;
                        DosDecimal = (decimal)datos.Lector["Precio"];
                        aux.Precio = Decimal.Parse(DosDecimal.ToString("0.00"));
                    }
                    aux.Genero = new Genero();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("genero"))))
                        aux.Genero.Descripcion = (string)datos.Lector["genero"];
                    aux.Categoria = new Categoria();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Categoria"))))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];



                }

                return aux;

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
                datos.setearConsulta("UPDATE ALBUMES set Activo = 0 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el álbum.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }



    
}

