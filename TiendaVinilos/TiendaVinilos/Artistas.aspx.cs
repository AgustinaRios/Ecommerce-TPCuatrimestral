﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace TiendaVinilos
{
    public partial class Artistas : System.Web.UI.Page
    {
        public List<Artista> listaArtista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            ArtistaNegocio negocio = new ArtistaNegocio();
            try
            {

                if (!IsPostBack)
                {
                    listaArtista = negocio.listar();

                    repRepetidor.DataSource = negocio.listar();
                    repRepetidor.DataBind();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
         

            

        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                ArtistaNegocio negocio = new ArtistaNegocio();

                negocio.AltaLogica(int.Parse(Id));
                Response.Redirect("Artistas.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta al artista: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                ArtistaNegocio negocio = new ArtistaNegocio();

                negocio.BajaLogica(int.Parse(Id));
                Response.Redirect("Artistas.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de baja al artista: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

        protected void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormAltaArtista.aspx");
        }
    }
    
}