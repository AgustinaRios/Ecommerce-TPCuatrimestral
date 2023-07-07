using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace TiendaVinilos
{
    public partial class Generos : System.Web.UI.Page
    {
        public List<Genero> listaGenero { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            GeneroNegocio negocio = new GeneroNegocio();
            try
            {

                if (!IsPostBack)
                {
                    listaGenero = negocio.listar();

                    repRepetidor.DataSource = negocio.listar();
                    repRepetidor.DataBind();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                GeneroNegocio negocio = new GeneroNegocio();

                negocio.BajaLogica(int.Parse(Id));
                Response.Redirect("Generos.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta un Genero: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                GeneroNegocio negocio = new GeneroNegocio();

                negocio.AltaLogica(int.Parse(Id));
                Response.Redirect("Generos.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta la Genero: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

        protected void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            
            Session["PaginaAnterior"] = Request.Url.ToString();
            Response.Redirect("FormAltaGenero.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            
        }
    }
}