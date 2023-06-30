using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Web.Configuration;
using Microsoft.Ajax.Utilities;

namespace TiendaVinilos
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        UsuarioNegocio negocio = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    Usuario usuario = new Usuario();
                    usuario = (Usuario)Session["usuario"];

                    int id = usuario.ID;
                    TxtNombre.Text = usuario.Nombre;
                    TxtApellido.Text = usuario.Apellido;
                    TxtEmail.Text = usuario.Email;

                }

            }
        }
        public void BtnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio=new UsuarioNegocio();
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["usuario"];

            usuario.Nombre = TxtNombre.Text;
            usuario.Apellido = TxtApellido.Text;
            usuario.Email = TxtEmail.Text;

            negocio.modificar(usuario);
            Response.Redirect("MiPerfil.aspx", false);
            

        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx", false);
        }

    }
}