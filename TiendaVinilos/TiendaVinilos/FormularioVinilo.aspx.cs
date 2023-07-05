﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

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
        public bool confirmaEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //se pone el checkbox en false para que solo aparecen cuando se elige eliminar
                    confirmaEliminacion = false;

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

                    Lbltitlulo.Text = "Alta de Albums"; //Cambia Dinamicamente dependiendo de donde entre

                    ///Toma el Id del album se se viene desde el boton de Modificar en el caso que no tenga Id cargado se asigna""
                    string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                    if (Id != "")

                    {
                        Album seleccionado = new Album();
                        seleccionado.Id = int.Parse(Id);
                        int idbuscado = seleccionado.Id;
                        seleccionado = negocio.ObtenerAlbum(idbuscado);
                        //se carga los datos del Album que se selecciono modificar
                        if (!seleccionado.Activo)
                        {
                            Lbltitlulo.Text = "Alta de Albums";
                        }
                        else
                        {
                            Lbltitlulo.Text = "Modificando Albums"; //Cambia Dinamicamente dependiendo de donde entre

                        }

                        TxtTitulo.Text = seleccionado.Titulo.ToString();
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
            catch (Exception ex)
            {
                throw ex;
            }

        }

        bool ValidarVacios()
        {
            TxtTitulo.BorderColor = Color.White;
            TxtImgTapa.BorderColor = Color.White;
            TxtImgContraTapa.BorderColor = Color.White;
            TxtFechaLanza.BorderColor = Color.White;

            bool vacios = false;
            if (TxtTitulo.Text == "")
            {
                TxtTitulo.BorderColor = Color.Red;
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
            if (TxtFechaLanza.Text == "")
            {
                TxtFechaLanza.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtPrecio.Text == "")
            {

                TxtPrecio.BorderColor = Color.Red;
                vacios = true;
            }

            return vacios;
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

               
                AlbumNegocio albumNegocio = new AlbumNegocio();

                
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
                nuevo.Artista = new Artista();
                nuevo.Artista.Id = int.Parse(ddlArtista.SelectedValue);
                nuevo.Activo = true;


                //////
                ///     PARA MODIFICAR UN ALBUM
                ///     
                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["Id"]);
                    if (ValidarVacios() == false)
                    {
                        albumNegocio.modificarConSP(nuevo);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert(' " + nuevo.Titulo + " modificado exitosamente');window.location ='Listar.aspx';", true);
                        // Response.Redirect("Listar.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('complete todos los campos');</script>");
                    }
                }
                else
                {
                    if (ValidarVacios() == false)
                    {
                        albumNegocio.agregar(nuevo);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert(' " + nuevo.Titulo + " Agregado exitosamente');window.location ='Listar.aspx';", true);
                        // Response.Redirect("Listar.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('complete todos los campos');</script>");
                    }

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



    }
}