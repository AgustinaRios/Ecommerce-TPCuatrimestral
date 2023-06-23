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
    public partial class RegistrarCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();
                usuario.Nombre = TxtNombre.Text;
                usuario.Apellido = TxtApellido.Text;
                usuario.Email = TxtEmail.Text;
                usuario.Pass = TxtPass.Text;

                int id = usuarioNegocio.insertarNuevo(usuario);

                emailService.armarCorreo(usuario.Email,"Bienvenidx a Tienda de Vinilos","Gracias por registrarte, esperamos que disfrutes tu experiencia!");
                emailService.enviarEmail();
                Response.Redirect("Inicio.aspx",false);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}