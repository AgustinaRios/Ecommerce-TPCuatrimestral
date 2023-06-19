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
        AlbumNegocio negocio = new AlbumNegocio();
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
                string Id = Request.QueryString["Id"].ToString();
                if (Id != "" && !IsPostBack)
                {

                    Album seleccionado = new Album();
                    seleccionado.Id = int.Parse(Id);
                    int idbuscado = seleccionado.Id;
                    seleccionado = negocio.ObtenerAlbum(idbuscado);
                    txtId.Text = seleccionado.Id.ToString();
                    txtId.ReadOnly = true;
                    TxtTitulo.Text = seleccionado.Titulo.ToString();
                    TxtArtista.Text = seleccionado.Artista.ToString();
                    TxtFechaLanza.Text = seleccionado.FechaLanzamiento.ToString();
                    TxtImgTapa.Text = seleccionado.ImgTapa.ToString();
                    TxtImgContraTapa.Text = seleccionado.ImgContratapa.ToString();

                    //////////////NO CARGA BIEN////////
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Descripcion.ToString();
                    ddlGenero.SelectedValue = seleccionado.Genero.Descripcion.ToString();


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //////
                ///     PARA AGREGAR UN NUEVO ALBUM
                ///     
                Album nuevo = new Album();
                nuevo.Titulo = TxtTitulo.Text;

                string nombreArtista = TxtArtista.Text;

                // Verificar si el artista ya existe
                ArtistaNegocio artistaNegocio = new ArtistaNegocio();
                Artista artistaExistente = artistaNegocio.ObtenerArtistaPorNombre(nombreArtista);
                AlbumNegocio albumNegocio = new AlbumNegocio();

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
                    nuevoArtista.Nombre = TxtArtista.Text;
                    artistaNegocio.agregar(nuevoArtista);
                    int idArtista = nuevoArtista.Id;
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


                //////
                ///     PARA MODIFICAR UN ALBUM
                ///     
                if (Request.QueryString["Id"]!=null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["Id"]);
                    albumNegocio.modificar(nuevo);
                    LblMensaje.Text = "El álbum se modifico exitosamente.";
                    LblMensaje.Visible = true;

                }
                else
                {
                albumNegocio.agregar(nuevo);

                LblMensaje.Text = "El álbum se agregó exitosamente.";
                LblMensaje.Visible = true;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}