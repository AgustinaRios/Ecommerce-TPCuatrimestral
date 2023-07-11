using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVinilos
{
    public partial class Categorias : System.Web.UI.Page
    {
        public List<Categoria> listaCategoria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("FiltroBusqueda", 3);
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {

                if (!IsPostBack)
                {
                    bool activos = false;
                    listaCategoria = negocio.listar(activos);

                    repRepetidor.DataSource = listaCategoria;
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
                CategoriaNegocio negocio = new CategoriaNegocio();

                negocio.BajaLogica(int.Parse(Id));
                Response.Redirect("Categorias.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta la categoría: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                CategoriaNegocio negocio = new CategoriaNegocio();

                negocio.AltaLogica(int.Parse(Id));
                Response.Redirect("Categorias.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta la categoría: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

        protected void btnAgregarNuevo_Click(object sender, EventArgs e)
        {

            Session["PaginaAnterior"] = Request.Url.ToString();
            Response.Redirect("FormAltaCategoria.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("FormAltaCategoria.aspx?Id=" + Id, false);

        }
    }
}