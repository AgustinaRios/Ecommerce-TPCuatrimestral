using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;

namespace TiendaVinilos
{
    public partial class FormularioVinilo : System.Web.UI.Page
    {

        GeneroNegocio genero = new GeneroNegocio();
        List<Genero> listaGenero = new List<Genero>();

        CategoriaNegocio categoria = new CategoriaNegocio();
        List<Categoria> listaCategoria = new List<Categoria>();

        ArtistaNegocio artista = new ArtistaNegocio();
        List<Artista> listaArtista = new List<Artista>();

        AlbumNegocio negocio = new AlbumNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {


                    CargarDdl();





                    ///Toma el Id del album que  viene desde el boton de Modificar en el caso que no tenga Id cargado se asigna""
                    string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                    Lbltitlulo.Text = "Alta de Albums";
                    if (Id != "")

                    {
                        Lbltitlulo.Text = "Modificando Albums"; //Cambia Dinamicamente dependiendo de donde entre
                        CargarAlbum(Id);
                    }


                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void btnAgregarArtista_Click(object sender, EventArgs e)
        {
            Session["PaginaAnterior"] = Request.Url.ToString();
            Response.Redirect("FormAltaArtista.aspx", false);
        }
        protected void btnAgregarGenero_Click(object sender, EventArgs e)
        {
            Session["PaginaAnterior"] = Request.Url.ToString();
            Response.Redirect("FormAltaGenero.aspx", false);
        }
        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Session["PaginaAnterior"] = Request.Url.ToString();
            Response.Redirect("FormAltaCategoria.aspx", false);
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Album nuevo = new Album();
                AlbumNegocio albumNegocio = new AlbumNegocio();



                if (ValidarVacios() == false)
                {
                    string fechaLanzamiento = TxtFechaLanza.Text;
                    if (!string.IsNullOrEmpty(fechaLanzamiento))
                    {
                        DateTime lanzamiento;
                        if (!DateTime.TryParse(fechaLanzamiento, out lanzamiento))
                        {
                            LblMensaje.Text = "La fecha de lanzamiento no es válida";
                            LblMensaje.Visible = true;
                            return;
                        }

                        if (lanzamiento >= DateTime.Now)
                        {
                            LblMensaje.Text = "No se puede cargar un álbum que no ha salido a la venta aún";
                            LblMensaje.Visible = true;
                            return;
                        }

                        nuevo.FechaLanzamiento = fechaLanzamiento; // Asignar la fecha de lanzamiento solo si es válida
                    }
                    else
                    {
                        nuevo.FechaLanzamiento = null; // Asignar null directamente cuando el campo de fecha está vacío
                    }
                    nuevo.Titulo = TxtTitulo.Text;
                    nuevo.ImgTapa = TxtImgTapa.Text;
                    nuevo.ImgContratapa = TxtImgContraTapa.Text;
                    nuevo.Precio = Decimal.Parse(TxtPrecio.Text);
                    nuevo.Genero = new Genero();
                    nuevo.Genero.Id = int.Parse(ddlGenero.SelectedValue);
                    nuevo.Categoria = new Categoria();
                    nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                    nuevo.Artista = new Artista();
                    nuevo.Artista.Id = int.Parse(ddlArtista.SelectedValue);

                    nuevo.Genero = new Genero { Id = int.Parse(ddlGenero.SelectedValue) };
                    nuevo.Categoria = new Categoria { Id = int.Parse(ddlCategoria.SelectedValue) };
                    nuevo.Artista = new Artista { Id = int.Parse(ddlArtista.SelectedValue) };

                    nuevo.Activo = true;

                    if (Request.QueryString["Id"] != null)
                    {


                        //////
                        ///     PARA MODIFICAR UN ALBUM
                        ///  
                        Album modificado = new Album();

                        int id = Int32.Parse(Request.QueryString["Id"]);


                        modificado.Id = id;
                        modificado.Titulo = TxtTitulo.Text;
                        modificado.FechaLanzamiento = TxtFechaLanza.Text;
                        //// Se valida que la fecha no sea posterior a la del dia actual
                        DateTime hoy = DateTime.Now;
                        DateTime Lanzamiento = DateTime.Parse(nuevo.FechaLanzamiento);
                        if (Lanzamiento >= hoy)
                        {
                            LblMensaje.Text = "No se puede cargar un album que no salio a la venta aun";
                            LblMensaje.Visible = true;
                            return;
                        }

                        modificado.ImgTapa = TxtImgTapa.Text;
                        modificado.ImgContratapa = TxtImgContraTapa.Text;
                        modificado.Precio = Decimal.Parse(TxtPrecio.Text);
                        modificado.Genero = new Genero();
                        modificado.Genero.Id = int.Parse(ddlGenero.SelectedValue);
                        modificado.Categoria = new Categoria();
                        modificado.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                        modificado.Artista = new Artista();
                        modificado.Artista.Id = int.Parse(ddlArtista.SelectedValue);
                        modificado.Activo = true;
                        albumNegocio.modificarConSP(modificado);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert(' " + nuevo.Titulo + " modificado exitosamente');window.location ='Listar.aspx';", true);
                        // Response.Redirect("Listar.aspx");
                    }
                    else
                    {


                        albumNegocio.agregar(nuevo);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert(' " + nuevo.Titulo + " Agregado exitosamente');window.location ='Listar.aspx';", true);
                        // Response.Redirect("Listar.aspx");

                    }

                   
                }

                else
                {
                    LblMensaje.Text = "Debe ingresar los campos obligatorios";
                    LblMensaje.Visible = true;
                    return;

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
        bool ValidarVacios()
        {
            TxtTitulo.BorderColor = Color.White;
            TxtPrecio.BorderColor = Color.White;
            TxtImgTapa.BorderColor = Color.White;
            TxtImgContraTapa.BorderColor = Color.White;
            TxtFechaLanza.BorderColor = Color.White;
            ddlArtista.BorderColor = Color.White;
            ddlCategoria.BorderColor = Color.White;
            ddlGenero.BorderColor = Color.White;

            bool vacios = false;
            if (TxtTitulo.Text == "")
            {
                TxtTitulo.BorderColor = Color.Red;
                vacios = true;
            }
            if (ddlArtista.SelectedIndex == 0)
            {
                ddlArtista.BorderColor = Color.Red;
                vacios = true;
            }
            if (ddlCategoria.SelectedIndex == 0)
            {
                ddlCategoria.BorderColor = Color.Red;
                vacios = true;
            }
            if (ddlGenero.SelectedIndex == 0)
            {
                ddlGenero.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtPrecio.Text == "")
            {

                TxtPrecio.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtImgTapa.Text == "")
            {

                TxtImgTapa.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtImgContraTapa.Text == "")
            {

                TxtImgContraTapa.BorderColor = Color.Red;
                vacios = true;
            }
            /* if (TxtFechaLanza.Text == "" )
           {

               TxtFechaLanza.BorderColor = Color.Red;
               vacios = true;
           }*/


            return vacios;
        }
        protected void CargarDdl()
        {
            //Genero
            listaGenero = genero.listar();
            listaGenero.Insert(0, new Genero { Id = -1, Descripcion = "Elegir Genero" });
            ddlGenero.DataSource = listaGenero;
            ddlGenero.DataTextField = "Descripcion";
            ddlGenero.DataValueField = "Id";
            ddlGenero.DataBind();

            ddlGenero.SelectedIndex = -1;

            //Categoria
            listaCategoria = categoria.listar();
            listaCategoria.Insert(0, new Categoria { Id = -1, Descripcion = "Elegir Categoria" });
            ddlCategoria.DataSource = listaCategoria;
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();

            ddlCategoria.SelectedIndex = -1;

            //Artista

            listaArtista = artista.listar();

            listaArtista.Insert(0, new Artista { Id = -1, Nombre = "Elegir Artista" });
            ddlArtista.DataSource = listaArtista;
            ddlArtista.DataTextField = "Nombre";
            ddlArtista.DataValueField = "Id";
            ddlArtista.DataBind();

            ddlArtista.SelectedIndex = -1;
        }
        protected void CargarAlbum(string Id)
        {
            Album seleccionado = new Album();
            seleccionado.Id = int.Parse(Id);
            int idbuscado = seleccionado.Id;
            seleccionado = negocio.ObtenerAlbum(idbuscado);
            //se carga los datos del Album que se selecciono modificar


            TxtTitulo.Text = seleccionado.Titulo.ToString();
            DateTime fecha = Convert.ToDateTime(seleccionado.FechaLanzamiento);
            TxtFechaLanza.Text = fecha.ToString("yyyy-MM-dd");

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
            /////////////////////////////////////////////////////

            List<Artista> artFiltrado = new List<Artista>();
            Artista artSeleccionado = new Artista();

            artFiltrado = listaArtista.FindAll(x => x.Nombre == seleccionado.Artista.ToString());
            artSeleccionado.Id = artFiltrado[0].Id;
            artSeleccionado.Nombre = seleccionado.Artista.ToString();

            ddlArtista.SelectedValue = artSeleccionado.Id.ToString();
            ddlArtista.SelectedValue = seleccionado.Artista.Id.ToString();
            ddlArtista.SelectedIndex = artSeleccionado.Id;


        }

    }
}