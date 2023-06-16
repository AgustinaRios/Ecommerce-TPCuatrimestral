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
    public partial class Formulario : System.Web.UI.Page
    {
        GeneroNegocio negocio = new GeneroNegocio();
        List<Genero> listaGenero = new List<Genero>();
        protected void Page_Load(object sender, EventArgs e)
        {
            listaGenero = negocio.listar();
            ddlGenero.DataSource = listaGenero;
            ddlGenero.DataTextField = "Descripcion";
            ddlGenero.DataValueField = "Id";
            ddlGenero.DataBind();
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}