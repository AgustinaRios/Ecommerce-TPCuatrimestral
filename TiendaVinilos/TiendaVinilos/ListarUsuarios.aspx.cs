using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVinilos
{
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        public List<Usuario> listaUsuarios { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "No tiene permisos para ingresar a esta pantalla");
                Response.Redirect("error.aspx");
            }

            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {

                if (!IsPostBack)
                {
                    listaUsuarios = negocio.listar();

                    repRepetidor.DataSource = negocio.listar();
                    repRepetidor.DataBind();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void BtnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarCuenta.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                UsuarioNegocio negocio = new UsuarioNegocio();

                negocio.Eliminar(int.Parse(Id));
                Response.Redirect("ListarUsuarios.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar usuario: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }
    }
}