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
    public partial class ComprasUsuarios : System.Web.UI.Page
    {
        public List<PedidoConUsuario> pedidos = new List<PedidoConUsuario>();
        PedidoNegocio pedidoNegocio = new PedidoNegocio();
        protected void Page_Load(object sender, EventArgs e)

        {
            Session.Add("FiltroBusqueda", 1);
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {


                if (!IsPostBack)
                {
                    string buscar = Request.QueryString["buscar"];

                    if (!string.IsNullOrEmpty(buscar))
                    {
                        pedidos = pedidoNegocio.BuscarPorUsuario(buscar);

                        repRepetidor.DataSource = pedidos;
                        repRepetidor.DataBind();

                    }

                    else

                    {
                        repRepetidor.DataSource = pedidoNegocio.ListarTodos();
                        repRepetidor.DataBind();

                    }


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("FormModificarEstadoCompra.aspx?Id=" + Id, false);
        }
    }
}
