using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
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

        bool ValidarVacios()
        {

            TxtApellido.BorderColor = Color.White;
            TxtNombre.BorderColor = Color.White;
            TxtEmail.BorderColor = Color.White;
            TxtDireccion.BorderColor = Color.White;
            TxtLocalidad.BorderColor = Color.White;
            TxtProvincia.BorderColor = Color.White;

            bool vacios = false;
            if (TxtApellido.Text == "")
            {
                TxtApellido.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtNombre.Text == "")
            {
                TxtNombre.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtEmail.Text == "")
            {
                TxtEmail.BorderColor = Color.Red;
                vacios = true;
            }

            if (TxtDireccion.Text == "")
            {
                TxtDireccion.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtLocalidad.Text == "")
            {
                TxtLocalidad.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtProvincia.Text == "")
            {
                TxtProvincia.BorderColor = Color.Red;
                vacios = true;
            }

            return vacios;
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
            if (ValidarVacios() == false)
            {
                negocio.modificar(usuario);
                Response.Redirect("Inicio.aspx", false);

            }
            else
            {
                LblMensaje.Text = "Complete todos los campos necesarios, por favor.";
                LblMensaje.Visible = true;
                return;
            }

        }

        public void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx", false);
        }

    }
}