
using Dominio;
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
    public partial class Listar : System.Web.UI.Page
    {
        public List<Album> listaAlbum { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {

            Session.Add("FiltroBusqueda", 2);
            AlbumNegocio negocio = new AlbumNegocio();
            try
            {
                Session.Remove("listaFiltrada");

                if (!IsPostBack)
                {
                    if (Session["listaFiltrada"] != null)
                    {
                        listaAlbum = (List<Album>)Session["listaFiltrada"];
                        repRepetidor.DataSource = listaAlbum;
                        repRepetidor.DataBind();

                    }
                    else
                    {
                        listaAlbum = new List<Album>();

                        bool activos=false;
                        listaAlbum = negocio.listar(activos);

                        repRepetidor.DataSource = listaAlbum;
                        repRepetidor.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("FormularioVinilo.aspx?Id=" + Id, false);

        }

        protected void BtnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioVinilo.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                AlbumNegocio negocio = new AlbumNegocio();

                negocio.BajaLogica(int.Parse(Id));
                Response.Redirect("Listar.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta la Albums: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                AlbumNegocio negocio = new AlbumNegocio();

                negocio.AltaLogica(int.Parse(Id));
                Response.Redirect("Listar.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta el albums: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }
    }
}