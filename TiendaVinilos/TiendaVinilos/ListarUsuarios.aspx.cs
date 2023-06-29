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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "No tiene permisos para ingresar a esta pantalla");
                Response.Redirect("error.aspx");
            }
        }

        protected void BtnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarCuenta.aspx");
        }
    }
}