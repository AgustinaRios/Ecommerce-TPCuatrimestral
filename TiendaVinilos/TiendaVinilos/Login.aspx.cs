using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using Dominio;
using Negocio;

namespace TiendaVinilos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            Usuario completo = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario.Email = TxtEmail.Text;
                usuario.Pass = TxtPass.Text;
                completo = negocio.Login(usuario);

               if (completo.ID!=0)
                {
                    Session.Add("usuario", completo);

                    if (Seguridad.esAdmin(Session["completo"]))
                    {
                        Response.Redirect("Inicio.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("MiPerfil.aspx", false);
                    }
                }
                else
                {
                    Session.Add("error", "Usuario o contraseña incorrectos");
                    Response.Redirect("error.aspx");
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx");
            }
        }
    }
}