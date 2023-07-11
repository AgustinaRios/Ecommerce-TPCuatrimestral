﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVinilos
{
    public partial class FormAltaArtista : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Artista artista = new Artista();
                ArtistaNegocio negocio = new ArtistaNegocio();
                if (!IsPostBack)
                {
                    string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                    if (Id != "")

                    {
                        int IdArtista = int.Parse(Id);
                        artista = negocio.ObtenerArtistaPorId(IdArtista);

                        TxtNombre.Text = artista.Nombre.ToString();


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
                ArtistaNegocio negocio=new ArtistaNegocio();
                Artista artista=new Artista();
                string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                if (Id != "")

                {
                    int IdArtista = int.Parse(Id);
                    artista = negocio.ObtenerArtistaPorId(IdArtista);
                    artista.Nombre = TxtNombre.Text;
                    negocio.modificar(artista);
                    LblMensaje.Text = "Artista modificado exitosamente";
                    LblMensaje.Visible = true;
                    Response.Redirect("Artistas.aspx", false);

                }
                else
                {

                Artista nuevo = new Artista();
                nuevo.Nombre = TxtNombre.Text;
               
                negocio.agregar(nuevo);
                LblMensaje.Text = "Artista agregado exitosamente";
                LblMensaje.Visible = true;

                string paginaAnterior = Session["PaginaAnterior"] as string;
                if (!string.IsNullOrEmpty(paginaAnterior))
                {
                    Response.Redirect(paginaAnterior, false);
                }

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);

            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            string paginaAnterior = Session["PaginaAnterior"] as string;
            if (!string.IsNullOrEmpty(paginaAnterior))
            {
                Response.Redirect(paginaAnterior, false);
            }
        }
    }
}