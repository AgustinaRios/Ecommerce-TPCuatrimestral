using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
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
        public bool confirmaEliminacion { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //se pone el checkbox en false para que solo aparecen cuando se elige eliminar
                    confirmaEliminacion = false;


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
                    Lbltitlulo.Text = "Alta de Albums";
                    ///Toma el Id del album se se viene desde el boton de Modificar en el caso que no tenga Id cargado se asigna""
                    string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                    if (Id != "")

                    {
                        Lbltitlulo.Text = "Modificando Albums";
                        Album seleccionado = new Album();
                        seleccionado.Id = int.Parse(Id);
                        int idbuscado = seleccionado.Id;
                        seleccionado = negocio.ObtenerAlbum(idbuscado);
                        //se carga los datos del Album que se selecciono modificar
                        TxtTitulo.Text = seleccionado.Titulo.ToString();
                        TxtArtista.Text = seleccionado.Artista.ToString();
                        TxtFechaLanza.Text = seleccionado.FechaLanzamiento.ToString("yyyy-MM-dd");
                        TxtPrecio.Text = seleccionado.Precio.ToString();
                        TxtImgTapa.Text = seleccionado.ImgTapa.ToString();
                        TxtImgContraTapa.Text = seleccionado.ImgContratapa.ToString();
                       

                        //////////////////////////////////////////////
                        ///
                        List<Categoria> filtrada = new List<Categoria>();
                        Categoria catSeleccionada = new Categoria();

                        ///se busca la categoria del Album seleccionado
                        filtrada = listaCategoria.FindAll(x => x.Descripcion == seleccionado.Categoria.ToString());
                        catSeleccionada.Id = filtrada[0].Id;
                        catSeleccionada.Descripcion = seleccionado.Categoria.ToString();


                        ddlCategoria.SelectedValue = catSeleccionada.Id.ToString();

                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                        ddlCategoria.SelectedIndex = catSeleccionada.Id;
                        /////////////////////////////////////////////////

                        List<Genero> genFiltrado = new List<Genero>();
                        Genero genSeleccionado = new Genero();


                        genFiltrado = listaGenero.FindAll(x => x.Descripcion == seleccionado.Genero.ToString());
                        genSeleccionado.Id = genFiltrado[0].Id;
                        genSeleccionado.Descripcion = seleccionado.Genero.ToString();


                        ddlGenero.SelectedValue = genSeleccionado.Id.ToString();

                        ddlGenero.SelectedValue = seleccionado.Genero.Id.ToString();

                        ddlGenero.SelectedIndex = genSeleccionado.Id;



                    }
                   

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
                ///
                ///  PARA AGREGAR UN NUEVO ALBUM
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
                //// Se valida que la fecha no sea posterior a la del dia actual
                DateTime hoy = DateTime.Now;
                if (nuevo.FechaLanzamiento >= hoy)
                {
                    LblMensaje.Text = "No se puede cargar un album que no salio a la venta aun";
                    LblMensaje.Visible = true;
                    return;
                }
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
                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["Id"]);
                    albumNegocio.modificarConSP(nuevo);
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
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listar.aspx", false);
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            confirmaEliminacion = true;
        }

        protected void btnConfirmaEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                    if (Id != "")

                    {
                        AlbumNegocio negocio = new AlbumNegocio();
                        Album seleccionado = new Album();
                        seleccionado = negocio.ObtenerAlbum(int.Parse(Id));
                        if (!seleccionado.Activo)
                        {
                            LblMensaje.Text = "El album ya se encuentra dado de baja";
                            LblMensaje.CssClass = "error-message";
                            LblMensaje.Visible = true;

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "confirm", "if(!confirm('esta seguro que quiere eliminar?')){window.location='Formulario.aspx'};",  true);
                        
                            
                            LblMensaje.Text = "El álbum se dio de baja correctamente.";
                            LblMensaje.Visible = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = "Error al dar de baja el álbum: " + ex.Message;
                LblMensaje.CssClass = "error-message";
                LblMensaje.Visible = true;

            }
        }
    }
}