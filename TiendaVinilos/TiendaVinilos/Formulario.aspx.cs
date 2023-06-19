using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace TiendaVinilos
{
    public partial class Formulario : System.Web.UI.Page
    {
        GeneroNegocio genero = new GeneroNegocio();
        List<Genero> listaGenero = new List<Genero>();
        CategoriaNegocio categoria = new CategoriaNegocio();
        List<Categoria> listaCategoria = new List<Categoria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    listaGenero = genero.listar();
                    ddlGenero.DataSource = listaGenero;
                    ddlGenero.DataTextField = "Descripcion";
                    ddlGenero.DataValueField = "Id";
                    ddlGenero.DataBind();
                    listaCategoria = categoria.listar();
                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();

                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Album nuevo = new Album();
                nuevo.Titulo = TxtTitulo.Text;

                string nombreArtista = TxtArtista.Text;

                // Verificar si el artista ya existe
                ArtistaNegocio artistaNegocio = new ArtistaNegocio();
                Artista artistaExistente = artistaNegocio.ObtenerArtistaPorNombre(nombreArtista);

                if (artistaExistente != null)
                {
                    // El artista ya existe, utiliza el artista existente
                    nuevo.Artista = new Artista();
                    nuevo.Artista.Id = artistaExistente.Id;
                    nuevo.Artista.Nombre = artistaExistente.Nombre;
                
                }
                else
                {
                    // El artista no existe, crea un nuevo artista
                    Artista nuevoArtista = new Artista();
                    nuevoArtista.Nombre =TxtArtista.Text;
                    artistaNegocio.agregar(nuevoArtista);
                   int  idArtista = nuevoArtista.Id;
                    if (idArtista != -1)
                    {
                        // Asigna el ID del nuevo artista al objeto nuevo.Artista
                        nuevo.Artista = new Artista();
                        nuevo.Artista.Id = idArtista;
                        nuevo.Artista.Nombre = nuevoArtista.Nombre;
                    }
                    else
                    {
                        // Ocurrió un error al agregar el artista
                        
                    }
                }
                
                nuevo.FechaLanzamiento = DateTime.Parse(TxtFechaLanza.Text);
                nuevo.ImgTapa = TxtImgTapa.Text;
                nuevo.ImgContratapa = TxtImgContraTapa.Text;
                nuevo.Precio = Decimal.Parse(TxtPrecio.Text);
                nuevo.Genero = new Genero();
                nuevo.Genero.Id = int.Parse(ddlGenero.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                AlbumNegocio albumNegocio = new AlbumNegocio();
                albumNegocio.agregar(nuevo);

                LblMensaje.Text = "El álbum se agregó exitosamente.";
                LblMensaje.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}