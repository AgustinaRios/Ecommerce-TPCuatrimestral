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

                    TxtApellido.Text = usuario.Apellido;

                    TxtNombre.Text = usuario.Nombre;
                    TxtEmail.Text = usuario.Email;
                    TxtDireccion.Text= usuario.Direccion;
                    TxtLocalidad.Text= usuario.Localidad;
                    TxtProvincia.Text=usuario.Provincia;

                }

            }
        }
        public void BtnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["usuario"];

            usuario.Nombre = TxtNombre.Text;
            usuario.Apellido = TxtApellido.Text;
            usuario.Email = TxtEmail.Text;
            usuario.Direccion = TxtDireccion.Text;
            usuario.Localidad= TxtLocalidad.Text;
            usuario.Provincia= TxtProvincia.Text;

            negocio.modificar(usuario);
            Response.Redirect("Inicio.aspx", false);


        }

        public void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx", false);
        }

    }
}